<template>
  <page-view :avatar=userInfo.avatar :title="false">
    <div slot="headerContent">
      <div class="title">{{ timeFix }}，{{ user.username }}！</div>
    </div>
    <a-row :gutter="24">
      <!--个人信息-->
        <a-col
          style="padding: 0 12px"
          :xl="8"
          :lg="24"
          :md="24"
          :sm="24"
          :xs="24">

          <!--个人信息-->
          <a-card
            style="margin-bottom: 24px; margin-top: 0px"
            :bordered="false"
            title="个人信息"
            :body-style="{ padding: 0 }">
            <a-card>
              <a-row style="margin-bottom: 12px">
                <a-icon type="idcard" theme="twoTone" twoToneColor="#3A5FCD"/>
                <strong> 用户名：</strong>
                {{ userInfo.username }}
              </a-row>
              <a-row style="margin-bottom: 12px">
                <a-icon type="tag" theme="twoTone" twoToneColor="#3A5FCD"/>
                <strong> 昵称：</strong>
                {{ userInfo.nickname }}
              </a-row>
              <a-row style="margin-bottom: 12px">
                <a-icon type="tag" theme="twoTone" twoToneColor="#3A5FCD"/>
                <strong> 出生日期：</strong>
                {{ userInfo.birthday }}
              </a-row>
              <a-row style="margin-bottom: 12px">
                <a-icon type="tag" theme="twoTone" twoToneColor="#3A5FCD"/>
                <strong> 性别：</strong>
                {{ userInfo.sex }}
              </a-row>
            </a-card>
          </a-card>
          <!--个人信息结束-->

          <!--密码修改-->
          <div>
            <a-row style="text-align: center">
              <a-button @click="modifyPassButton" type="primary" icon="lock"> 修改密码</a-button>
              <a-modal v-model="showPasswordForm" footer="">
                <a-form title="修改密码" @submit="handleSubmit" :form="form">
                  <a-form-item
                    :wrapperCol="{ span: 24 }"
                    style="text-align: center">
                    <h3>修改密码</h3>
                  </a-form-item>
                  <a-form-item
                    label="旧密码"
                    :labelCol="{lg: {span: 7}, sm: {span: 7}}"
                    :wrapperCol="{lg: {span: 10}, sm: {span: 17} }">
                    <a-input
                      type="password"
                      v-decorator="[
                        'old_password',
                        {rules: [{ required: true, message: '请输入旧的密码' }]}
                      ]"
                      name="old_password"
                      placeholder="请输入旧的密码"/>
                  </a-form-item>
                  <a-form-item
                    label="新密码"
                    :labelCol="{lg: {span: 7}, sm: {span: 7}}"
                    :wrapperCol="{lg: {span: 10}, sm: {span: 17} }">
                    <a-input
                      type="password"
                      v-decorator="[
                      'new_password',
                       {rules: [{ required: true, message: '请输入新的密码' }]}
                      ]"
                      name="new_password"
                      placeholder="请输入新的密码"/>
                  </a-form-item>
                  <a-form-item
                    :wrapperCol="{ span: 24 }"
                    style="text-align: center">
                    <a-button htmlType="submit" type="primary">提交</a-button>
                    <a-button style="margin-left: 8px" @click="cancelModifyPassword">取消</a-button>
                  </a-form-item>
                </a-form>
              </a-modal>
            </a-row>
          </div>
          <!--密码修改结束-->
        </a-col>
      <a-col :xl="16" :lg="24" :md="24" :sm="24" :xs="24">
        <a-card
          style="width:100%"
          :tabList="tabListNoTitle"
          :activeTabKey="noTitleKey"
          @tabChange="key => onTabChange(key, 'noTitleKey')"
        >
      <template v-if="noTitleKey === '我的讨论'">
        <a-list :dataSource="postData">
          <a-list-item slot="renderItem" slot-scope="item, index">
             <a slot="actions" @click="onClickDelete(item.id)">删除</a>
             <a-modal
                title="确认删除"
                :visible="visible3"
                @ok="onDeleteSpeech"
                @cancel="onClickCancel"
             >
             <div class="modal">
                是否删除本条帖子
             </div>
             </a-modal>
              <a-list-item-meta :title='item.title'>
                <a-avatar
                  width="72"
                  slot="avatar"
                  :src="item.avatar"
                />
                <div slot="description">
                  <ellipsis :length="70">{{ item.content }}</ellipsis>
                </div>
                <br/>
                <div slot="description">
                  <ellipsis :length="70">{{ item.time }}</ellipsis>
                </div>

              </a-list-item-meta>
              <div>
                 <router-link :to="{ name: 'postDetail', params:{ id: item.id} }">帖子详情</router-link>
              </div>
          </a-list-item>
        </a-list>
        <div style="margin-top:20px">
          <a-pagination @change="onChange1" :current="current1" :total="totalPage1*10" />
        </div>
      </template>
      <template v-if="noTitleKey === '收藏'">
        <a-list :dataSource="likeData">
          <a-list-item>
            <a-card :bordered="false" style="width:100%">
              <a-card-meta title="item.title">
                <img style="width:100px"
                   slot="avatar"
                   :src="item.image"
                 />
              </a-card-meta>
            </a-card>
          </a-list-item>
        </a-list>
        <div style="margin-top:20px">
          <a-pagination @change="onChange2" :current="current2" :total="totalPage2*10" />
        </div>
      </template>
       </a-card>
      </a-col>
    </a-row>
  </page-view>
</template>

<script>
import { STable } from '@/components'
import { PageView } from '@/layouts'
import Fuse from 'fuse.js'
import md5 from 'md5'
import ARow from "ant-design-vue/es/grid/Row";
import ACol from "ant-design-vue/es/grid/Col";
import {timeFix} from '@/utils/util'
import {mapGetters} from 'vuex'
import {Button} from 'ant-design-vue'
import HeadInfo from '@/components/tools/HeadInfo'
import {Radar} from '@/components'
import {getMyPost, getMyLike} from '@/api/myInfo'
import {deleteSpeech} from '@/api/chat'
import AFormItem from "ant-design-vue/es/form/FormItem";

export default {
  
  components: {
    AFormItem,
    ACol,
    ARow,
    PageView,
    Radar,
    STable,
  },

  inject: ['reload'],
    
  data() {
    return {
        timeFix: timeFix(),
        avatar: '',
        user: {},
        projects: [],
        loading: true,
        radarLoading: true,
        activities: [],
        teams: [],
        old_password: '',
        new_password: '',
        form: this.$form.createForm(this),
        showPasswordForm: false,
        new_identity: {
          id: '',
          newPassword: '',
        },
        visible3: false,
        postData: [],
        likeData: [],
        allPostData: [],
        allLikeData: [],
        totalPage1: '',
        totalPage2: '',
        current1: 1,
        current2: 1,
        loading: true,
        radarLoading: true,
        toDelete:'',
        confirmLoading: false,
          //userInfo:this.$store.getters.userInfo,

        tabList: [
          {
            key: 'tab1',
            // tab: 'tab1',
            scopedSlots: { tab: 'customRender' },
          },
          {
            key: 'tab2',
            tab: 'tab2',
          },
        ],
        tabListNoTitle: [
          {
            key: '我的讨论',
            tab: '我的讨论',
          },
          {
            key: '收藏',
            tab: '收藏',
          },
        ],
        key: 'tab1',
        noTitleKey: '我的讨论',
    };
  },

    computed: {
      userInfo() {
        return this.$store.getters.userInfo
      }
    },

    created() {
      this.user = this.$store.getters.userInfo
      this.avatar = this.userInfo.avatar
    },

    methods: {
      ...mapGetters(['nickname', 'welcome']),

      cancelModifyPassword() {
        console.log('Cancel modify passsword')
      },

      modifyPassButton() {
        this.showPasswordForm = true;
      },

      cancelModifyPassword() {
        this.showPasswordForm = false;
      },

      handleSubmit(e) {
        e.preventDefault()
        this.form.validateFields((err, value) => {
          if (!err) {
            if (md5(value.old_password) === this.userInfo.password) {
              this.new_identity.newPassword = md5(value.new_password)
              this.new_identity.id = this.userInfo.id
              console.log(this.new_identity)
              modifyPassword(this.new_identity).then(() => {
                this.$message.success('密码修改成功！')
              })
              console.log("Pass!")
            } else {
              this.$message.error('旧密码输入错误！')
              console.log("Failed!")
            }
          }
        })
        this.showPasswordForm = false;
      },

      onClickCancel(){
        this.visible3=false;
      },

      onChange1(current){
        this.current1=current;
          getMyPost({User:this.user.id,Page:this.current1}).then( response =>{
            console.log("getMyPost2", response);

            this.allPostData=response.Data;
            this.postData=this.allPostData.Data;
            this.totalPage1=this.allPostData.Total
          })
      },

      onChange2(current){
        this.current2=current;
        getMyLike(this.current2).then((response)=>{
          console.log(response);
          console.log(this.page);
          this.allLikeData=response.data;
          this.likeData=this.allLikeData.likeData;
          this.totalPage2=this.allLikeData.total //总页数
        })
      },

      onClickDelete (id) {
        console.log(id)
        this.toDelete = id
        this.visible3 = true;
      },

      onDeleteSpeech () {
        this.visible3 = false
        console.log("onDeleteSpeech")

        deleteSpeech(this.toDelete).then(response => {
          console.log("deleteSpeech", response)
          if(response.Code === 200){
            //this.sfData = [...response.Data]
            //this.sfDataShow = this.sfData
            this.$notification.open({
              message: '删除成功',
              description: '本条信息删除成功',
              icon: <a-icon type="check" style="color: #108ee9" />,
            });
            this.reload();
          }else{
            this.$notification.open({
            message: '删除失败',
            description: '本条信息删除失败',
            icon: <a-icon type="warning" style="color: #108ee9" />,
        });
        
      }

    })
    },
  },



    mounted(){

      getMyPost({User:this.user.id,Page:1}).then( response =>{
        console.log("getMyPost", response);
        this.allPostData=response.Data;
        this.postData=this.allPostData.Data;
        this.totalPage1=this.allPostData.Total

      }),

      getMyLike({User:this.user.id,Page:1}).then(response =>{
        console.log(response);

        this.allLikeData=response.data;
        this.likeData=this.allLikeData.likeData;
        this.totalPage2=this.allLikeData.totalPage //总页数
      })
    }
}

</script>

<style lang="less" scoped>
.addButton{
    position: absolute;
    z-index: 999;
    right:1em;
    top:0em;
  }
</style>