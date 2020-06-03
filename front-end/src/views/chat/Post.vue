<template>
  <page-view :avatar="avatar" :title="帖子">
        <div id="layout">
              <a-button
                style="margin-right : 1rem"
                @click="handleAdd()"
                type="primary"
                icon="plus"
              >交流
              </a-button>
        </div>

      <a-card style="top:10px">
      <a-list itemLayout="horizontal" :dataSource="Data">
        <!--单条帖子-->
          <a-list-item slot="renderItem" slot-scope="item, index">
          <!--删除帖子-->
          <!--
            <a slot="actions" @click="onClickDelete(item)">删除</a>
            <a-modal
                title="确认删除"
                :visible="visible3"
                @ok="onClickDeleteRow"
                :confirmLoading="confirmLoading"
                @cancel="Cancel"
            >
            <div>
                是否删除本条帖子
             </div>
             </a-modal>
           -->
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
                  <ellipsis :length="70">{{ item.sendTime }}</ellipsis>
                </div>

              </a-list-item-meta>
              <div>
                 <router-link :to="{ name: 'postDetail', params:{ id: item.id} }">详情</router-link>
              </div>
          </a-list-item>

      </a-list>
      <!--换页-->
      <div style="margin-top:20px">
        <a-pagination @change="onChangePage" :current="current" :total="totalPage*8" />
      </div>
    </a-card>
    <!--发言-->
    <a-modal
              title="交流"
              :visible="visible"
              @ok="onDeliverSpeech"
              :confirmLoading="confirmLoading"
              @cancel="handleCancel"
            >
            <a-form :from="(form)=>{this.form = form} " rowKey='id' bordered>
              <a-form-item
                :labelCol="labelCol"
                :wrapperCol="wrapperCol"
                label="标题"
                :validateStatus="successAddTitle"
                hasFeedback
              >
                <a-input placeholder="请输入标题" v-model="newSpeech.Title" id="post_title"/>
              </a-form-item>

              <a-form-item
                :labelCol="labelCol"
                :wrapperCol="wrapperCol" 
                label="内容"
                :validateStatus="successAddContent"
                hasFeedback
              >
                <a-input placeholder="请输入内容" v-model="newSpeech.Content" id="post_content"/>
              </a-form-item>
              <!--<a-form-item
                :labelCol="labelCol"
                :wrapperCol="wrapperCol"
                label="是否匿名"
                hasFeedback
              > 
                <template>
                    <a-radio-group @change="onChange" defaultValue="1">
                        <a-radio :value="1">匿名</a-radio>
                        <a-radio :value="2">不匿名</a-radio>
                    </a-radio-group>
                </template>
              </a-form-item>-->
            </a-form>
    </a-modal>
    <a-modal
          title="确认发布"
          :visible="confirmDeliverVisible"
          @ok="onConfirmDeliver"
          @cancel="onCancelDeliver"
        >
          <div class="modal">
            是否确认发布
          </div>
    </a-modal>
  </page-view>
</template>

<script>
import moment from 'moment'
import { TagSelect, StandardFormRow, Ellipsis, AvatarList } from '@/components'
import Fuse from 'fuse.js'
import { getPost, deliverSpeech, deleteSpeech} from '@/api/chat'
  import {timeFix} from '@/utils/util'
  import {mapGetters} from 'vuex'
  import {Button} from 'ant-design-vue'
  import {PageView} from '@/layouts'
  import HeadInfo from '@/components/tools/HeadInfo'
  import {Radar} from '@/components'
  import ARow from "ant-design-vue/es/grid/Row";
  import ACol from "ant-design-vue/es/grid/Col";
  import AFormItem from "ant-design-vue/es/form/FormItem";

  const DataSet = require('@antv/data-set')

  export default {
      inject:['reload'],
      name: 'post',
      components: {
      AFormItem,
      ACol,
      ARow,
      PageView,
      HeadInfo,
      Radar
    },
    data() {
      return {
        value: 1,
        Data:[],
        allData:[],
        user: {},
        current: 1,
        totalPage: '',
        visible: false,
        visible3: false,
        confirmDeliverVisible: false,
        todelete:'',
        owner:'',
        newSpeech:{
          Title:'',
          Content:'',
          User: '',
          //anonymous: '',
        },
      }
    },
    computed: {
      successAddTitle: function(){
        if(this.newSpeech.Title === ''){
          return "error"
        }
        return "success"
      },
      successAddContent: function(){
        if(this.newSpeech.Content === ''){
          return "error"
        }
        return "success"
      },
      userInfo() {
        return this.$store.getters.userInfo
      }
    },
    created() {
      this.user = this.userInfo
    },


   methods: {

      onClickDelete (item) {
        this.todelete = item.id;
        this.owner = item.owner;
        console.log(this.owner);
        console.log(this.userInfo.id);
        if(this.owner==this.userInfo.id){
          this.visible3 = true;
        }else{
          this.$notification.open({
          message: '删除失败',
          description: '删除失败，您没有删除的权限',
          icon: <a-icon type="warning" style="color: #108ee9" />,
        })
       }
      },

      Cancel(){
        this.visible3=false;
      },


      onChange(e) {
        console.log("checked ="+` ${e.target.value}`);
        //this.newSpeech.anonymous=(`${e.target.value}`);
      },


      onChangePage(current) {

           this.current = current;
           console.log("onChangePage", this.current)

           // 发送换页请求
           getPost(this.current).then(response => {
              console.log("onChangePage ", response)
              this.allData=response.Data;
              console.log(this.allData);

              //当前页的发言信息
              this.Data=this.allData.Data; 
              //总页数
              this.totalPage=this.allData.Total 
           })
      },

      handleAdd () {
          this.visible = true
      },

      handleCancel(){
          this.visible=false
      },

      onCancelDeliver(){
          this.confirmDeliverVisible=false
      },


      onDeliverSpeech(){
        this.visible=false
        if(this.successAddTitle === "error"||this.successAddContent === "error"){
          this.$notification.open({
            message: '发布失败',
            description: '请按要求填写发言信息',
            icon: <a-icon type="exclamation-circle" style="color: #108ee9" />,
          });
          return;
        }
        this.confirmDeliverVisible = true
      },

      onClickDeleteRow () {
        this.visible3 = false
        deleteSpeech({id:this.todelete}).then(response => {
        this.deleteInfo = response.code
            console.log(response.code)
            if(this.deleteInfo === 200){
                this.$notification.open({
                    message: '删除成功',
                    description: '本条信息删除成功',
                    icon: <a-icon type="check" style="color: #108ee9" />,
            });
        }
        else{
          this.$notification.open({
          message: '删除失败',
          description: '本条信息删除失败',
          icon: <a-icon type="warning" style="color: #108ee9" />,
        });
        }
      })
        this.reload()
      },

      onClickRefresh(){
        this.reload()
      },


      onConfirmDeliver(){
        this.visible = false
        this.confirmDeliverVisible = false
        this.newSpeech.User = this.userInfo.id
        console.log("msg ", this.newSpeech)
        deliverSpeech(this.newSpeech).then( response => {
          console.log("deliverSpeech", response)
          this.addInfo = response.Code
          if(response.Code === 200){
            this.$notification.open({
            message: '发布成功',
            description: '本条信息发布成功',
            icon: <a-icon type="check" style="color: #108ee9" />,
            });
          }else{
            this.$notification.open({
            message: '发布失败',
            description: '本条信息发布失败',
            icon: <a-icon type="warning" style="color: #108ee9" />,
          });
        }
        })
        this.reload()
      },
    },


    mounted() {
      console.log('userInfo', this.userInfo)
      getPost(this.current).then(response =>{
        console.log("mounted ",response)

        // 返回信息
        this.allData=response.Data;
        // 当前页的发言信息
        this.Data=this.allData.Data; 
        // 总页数
        this.totalPage=this.allData.Total 

      })
    }

  }
</script>

<style lang="less" scoped>
  .project-list {

    .card-title {
      font-size: 0;

      a {
        color: rgba(0, 0, 0, 0.85);
        margin-left: 12px;
        line-height: 24px;
        height: 24px;
        display: inline-block;
        vertical-align: top;
        font-size: 14px;

        &:hover {
          color: #1890ff;
        }
      }
    }

    .card-description {
      color: rgba(0, 0, 0, 0.45);
      height: 44px;
      line-height: 22px;
      overflow: hidden;
    }

    .project-item {
      display: flex;
      margin-top: 8px;
      overflow: hidden;
      font-size: 12px;
      height: 20px;
      line-height: 20px;

      a {
        color: rgba(0, 0, 0, 0.45);
        display: inline-block;
        flex: 1 1 0;

        &:hover {
          color: #1890ff;
        }
      }

      .datetime {
        color: rgba(0, 0, 0, 0.25);
        flex: 0 0 auto;
        float: right;
      }
    }

    .ant-card-meta-description {
      color: rgba(0, 0, 0, 0.45);
      height: 44px;
      line-height: 22px;
      overflow: hidden;
    }
  }

  .item-group {
    padding: 20px 0 8px 24px;
    font-size: 0;

    a {
      color: rgba(0, 0, 0, 0.65);
      display: inline-block;
      font-size: 14px;
      margin-bottom: 13px;
      width: 25%;
    }
  }

  .members {
    a {
      display: block;
      margin: 12px 0;
      line-height: 24px;
      height: 24px;

      .member {
        font-size: 14px;
        color: rgba(0, 0, 0, .65);
        line-height: 24px;
        max-width: 100px;
        vertical-align: top;
        margin-left: 12px;
        transition: all 0.3s;
        display: inline-block;
      }

      &:hover {
        span {
          color: #1890ff;
        }
      }
    }
  }

  .mobile {

    .project-list {

      .project-card-grid {
        width: 100%;
      }
    }

    .more-info {
      border: 0;
      padding-top: 16px;
      margin: 16px 0 16px;
    }

    .headerContent .title .welcome-text {
      display: none;
    }
  }

</style>
