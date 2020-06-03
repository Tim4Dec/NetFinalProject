<template>
  <page-view title="帖子详情">
      <a-card >
        <h3><strong>标题：{{post_title}}</strong></h3>
      </a-card>
    <a-card style="width:100%">
      <a-card-meta :title="post_content" :description="post_sendTime">
        <a-avatar
           slot="avatar"
           :src="post_headPortrait"
        />
      </a-card-meta>
      <p><strong>{{post_owner}}</strong></p>
      <p>楼主</P>
    </a-card>
    <template>
    <a-card style="top:10px">
      <a-list bordered :dataSource="data" class="comment-list">
          <a-list-item slot="renderItem" slot-scope="item, index">
            <a-comment :author="item.nickname" :avatar="item.avatar">
              <p slot="content">{{item.content}}</p>
              <p>{{item.floor}}楼</p>
              <a-tooltip slot="datetime">
                <span>{{item.time}}</span>
              </a-tooltip>
            </a-comment>
          </a-list-item>
      </a-list>
      <div style="margin-top:20px">
        <a-pagination @change="onChangePage" :current="current" :total="totalPage*10" />
      </div>
    </a-card>
    </template>
    <template>
      <div>
        <a-comment>
          <a-avatar
            id = "avatar"
            slot="avatar"
            :src="this.avatar"
          />
          <div slot="content">
            <a-form-item>
              <a-textarea :rows="4" @change="handleChange" :value="commentContent"></a-textarea>
            </a-form-item>
            <!--
            <template>
              <a-radio-group @change="onChange1" defaultValue="1">
                 <a-radio :value="1">匿名</a-radio>
                 <a-radio :value="2">不匿名</a-radio>
              </a-radio-group>
            </template>
            -->
            <a-form-item>
              <a-button htmlType="submit" :loading="submitting" @click="onSubmitComment" type="primary">
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
import { postDetail, sendComment, getComment } from '@/api/chat'
import Fuse from 'fuse.js'
//import moment from 'moment';

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
        //moment,
        current: 1,
        totalPage:'',
        data: [],
        post_title: '',
        post_content: '',
        post_sendTime: '',
        post_owner:'',
        post_headPortrait: '',//楼主的头像
        postID: this.$route.params.id,
        comment:{
          'Content':'',
          'Speech':'',
          'User':'',
        }
    };
   },

 
    computed: {
      userInfo() {
        return this.$store.getters.userInfo
      }
    },

    created() {
      this.user = this.userInfo
      this.avatar = this.userInfo.avatar
    },

    methods: {
     
    /*
      onChange1(e) {
        console.log(`checked = ${e.target.value}`);
        this.comment.anonymous=(`${e.target.value}`);
      },
    */

      onSubmitComment() {
        if (!this.commentContent) {
          return;
        }
        this.submitting = true;
        setTimeout(() => {
          this.submitting = false;
          this.comment.Speech = this.postID,
          this.comment.Content = this.commentContent,
          this.comment.User = this.userInfo.id
          console.log("comment", this.comment),

            sendComment(this.comment).then( response => {
              if(response.Code === 200){
                this.$notification.open({
                  message: '评论成功',
                  description: '本条树洞评论成功',
                  icon: <a-icon type="check" style="color: #108ee9" />,
                });
                this.Data = [...response.data]
                //this.DataShow = this.Data

              }else{
                this.$notification.open({
                  message: '评论失败',
                  description: '本条树洞评论失败',
                  con: <a-icon type="warning" style="color: #108ee9" />,
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


      onChangePage(current){
        this.current=current;
        getComment({Speech:this.postID,Page:this.current}).then(response => {
          console.log("onChangePage ", response);
          this.data=response.Data.Data;
          this.totalPage=response.Data.Total;
        })
      },

    },


    mounted() {

      postDetail(this.postID).then( response =>{
        console.log(response);
        let speech = response.Data;
        this.post_title=speech.title;
        this.post_content=speech.content;
        this.post_sendTime=speech.time;
        this.post_headPortrait=speech.avatar;
        this.post_owner=speech.nickname;
      }),


      getComment({Speech:this.postID,Page:1}).then(response =>{
        console.log("comments ", response)
        this.data=response.Data.Data;
        console.log("Data ",this.data)
        this.totalPage=response.Data.Total;
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
