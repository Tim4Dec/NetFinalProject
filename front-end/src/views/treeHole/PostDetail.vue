<template>
  <page-view title="帖子详情">
      <a-card >
        <h3>{{post_title}}</h3>
      </a-card>
    <a-card style="width:100%">
      <a-card-meta :title="post_content" :description="post_sendTime">
        <a-avatar
           slot="avatar"
           :src="post_headPortrait"
        />
      </a-card-meta>
      <p>{{post_owner}}</p>
      <p>楼主</P>
    </a-card>
    <template>
    <a-card style="top:10px">
      <a-list bordered :dataSource="data" class="comment-list">
          <a-list-item slot="renderItem" slot-scope="item, index">
            <a-comment :author="item.name" :avatar="item.headPortrait">
              <p slot="content">{{item.comment.content}}</p>
              <p>{{item.comment.floor}}楼</p>
              <a-tooltip slot="datetime">
                <span>{{item.comment.sendTime}}</span>
              </a-tooltip>
            </a-comment>
          </a-list-item>
      </a-list>
      <div style="margin-top:20px">
        <a-pagination @change="onChange" :current="current" :total="(totalPage+1)*10" />
      </div>
    </a-card>
    </template>
    <template>
      <div>
        <a-comment>
          <a-avatar
            slot="avatar"
            src="/avatar2.jpg"
          />
          <div slot="content">
            <a-form-item>
              <a-textarea :rows="4" @change="handleChange" :value="commentContent"></a-textarea>
            </a-form-item>
            <template>
              <a-radio-group @change="onChange1" defaultValue="1">
                 <a-radio :value="1">匿名</a-radio>
                 <a-radio :value="2">不匿名</a-radio>
              </a-radio-group>
            </template>
            <a-form-item>
              <a-button htmlType="submit" :loading="submitting" @click="handleSubmit" type="primary">
                评论
              </a-button>
            </a-form-item>
          </div>
        </a-comment>
      </div>
    </template>
  </page-view>
</template>

<script>
import { PageView } from '@/layouts'
import { postDetail, sendComment, getComment } from '@/api/Treehole'
import Fuse from 'fuse.js'
import moment from 'moment';

export default {
  inject: ['reload'],
  name: 'PostDetail',
  components: {
    PageView
  },
  data() {
    return {
        value: 1,
        comments: [],
        submitting: false,
        commentContent: '',
        moment,
        current: 1,
        totalPage:'',
        data: [],
        allData: [],
        post_title: '',
        post_content: '',
        post_sendTime: '',
        post_owner:'',
        post_headPortrait: '',//楼主的头像
        postID: this.$route.params.id,
        sendInfo:'',//评论是否成功信息
        comment:{
          'treeholeId':'',
          'content':'',
          'anonymous':'',
        }

      };
   },
   methods: {
      onChange1(e) {
        console.log(`checked = ${e.target.value}`);
        this.comment.anonymous=(`${e.target.value}`);
      },
      addComment(){
          console.log("comment")
        /*sendComment(this.comment).then((response) => {
        this.sendInfo = response.code
        if(this.sendInfo === 200){
          this.$notification.open({
          message: '评论成功',
          description: '本条树洞评论成功',
          icon: <a-icon type="check" style="color: #108ee9" />,
        });
          this.Data = [...response.data]
          this.DataShow = this.Data
        }
        else{
          this.$notification.open({
          message: '评论失败',
          description: '本条树洞评论失败',
          icon: <a-icon type="warning" style="color: #108ee9" />,
        });
        }
       })*/
      },
      handleSubmit() {
        if (!this.commentContent) {
          return;
        }
        this.submitting = true;
        setTimeout(() => {
          this.submitting = false;
          this.comment.treeholeId=this.postID,
          this.comment.content=this.commentContent,
          console.log(this.comment),
          //addComment(),
              sendComment(this.comment).then((response) => {
                  this.sendInfo = response.code
                  if(this.sendInfo === 200){
                      this.$notification.open({
                          message: '评论成功',
                          description: '本条树洞评论成功',
                          icon: <a-icon type="check" style="color: #108ee9" />,
                  });
                      this.Data = [...response.data]
                      this.DataShow = this.Data
                  }
                  else{
                      this.$notification.open({
                          message: '评论失败',
                          description: '本条树洞评论失败',
                          icon: <a-icon type="warning" style="color: #108ee9" />,
                  });
                  }
              })
            this.reload()
          this.commentContent = '';
        }, 1000);
      },
      handleChange(e) {
        this.commentContent = e.target.value;
      },
      onChange(current){
        this.current=current;
        getComment({id:this.postID,page:this.current-1}).then((response)=>{
        console.log(response);
        console.log(this.postID);
        this.allData=response.data;
        this.data=this.allData.comment;
        this.totalPage=this.allData.total;
      })
      },
    },
    mounted() {
      postDetail({id:this.postID}).then((response)=>{
        console.log(response);
        this.allData=response.data;
        let treehole=response.data.treehole;
        this.post_title=treehole.title;
        this.post_content=treehole.content;
        this.post_sendTime=treehole.sendTime;
        this.post_headPortrait=this.allData.headPortrait;
        this.post_owner=this.allData.name;
      }),
      getComment({id:this.postID,page:this.current-1}).then((response)=>{
        console.log(response);
        this.allData=response.data;
        this.data=this.allData.comment;
        this.totalPage=this.allData.total;
      })
    },
}

</script>

<style lang="less" scoped>
@import '~ant-design-vue/lib/style/themes/default.less';
#layout .ant-layout-header {
  background: #fff;
  color: #666;
}
.button-group {
  margin-top: 1rem;
  margin-bottom: 1rem;
  .button {
    margin-right: 5rem;
    margin-left: 0.5rem;
  }
}

.modal {
  margin-top: 1rem;
  margin-bottom: 1rem;
  .modal-number {
    margin-left: 0.6rem;
  }
}
</style>
