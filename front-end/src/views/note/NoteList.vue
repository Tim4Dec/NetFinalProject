<template>
  <a-row :gutter="24">
    <a-col :xl="24" :lg="24" :md="24" :sm="24" :xs="24">
      <!--通知栏-->
      <a-card
        style="margin-bottom: 0px; margin-top: 0px"
        :bordered="true"
        title="通知栏"
        :body-style="{ padding: 10 }">

        <!--搜索框-->
        <div slot="extra">
          <a-input-search style="margin-left: 16px; width: 270px;"/>
        </div>

        <!--
                添加
                <div class="operate">
                  <a-button type="dashed" style="width: 100%" icon="plus" @click="$refs.taskForm.add()">添加</a-button>
                </div>
        -->

        <a-list size="large" :datasrc="data"
                :pagination="{showSizeChanger: false, showQuickJumper: false, pageSize: 5, total: 50}">
          <a-list-item :key="index" v-for="(item, index) in data">
            <a-list-item-meta :description="item.content | ellipsis">
              <a-avatar slot="avatar" size="large" shape="square" icon="mail"/>
              <a slot="title">{{ item.title }}</a>
            </a-list-item-meta>
            <div class="list-content">
              <div class="list-content-item">
                <span style="text-align: center">收件时间</span>
                <p>{{ item.announcementTime }}</p>
              </div>
            </div>
            <a-button type="primary" class="cardItemContent" style="margin: 0 0 0 50px">
              <router-link :to="{ name: 'NoteDetail', params:{ id: item.id} }">查看消息</router-link>
            </a-button>

          </a-list-item>
        </a-list>

        <task-form ref="taskForm"/>

      </a-card>
    </a-col>
  </a-row>

</template>

<script>
  import HeadInfo from '@/components/tools/HeadInfo'
  import TaskForm from './modules/TaskForm'
  import moment from 'moment'
  import {getNoteList} from '@/api/note'
  import {PageView} from '@/layouts'

  export default {
    name: 'NoteList',

    components: {
      HeadInfo,
      TaskForm,
      PageView,
    },

    filters: {
      /*省略多余描述*/
      ellipsis (value) {
        if (!value) return ''
        if (value.length > 20) {
          return value.slice(0,20) + '······'
        }
        return value
      }
    },

    data() {
      return {
        data: [],
      }
    },


    mounted() {
      getNoteList({'pageNum':1}).then((response) => {
        console.log('初始化成功', response.data)
        this.allData = response.data
          this.data=this.allData.content
      })

    },


  }


  /*
    export function interceptImg (el, binding) {
      el.addEventListener('load', () => {
        let width = el.naturalWidth;
        let height = el.naturalHeight;
        // 获取父元素的设定宽度
        let parentWidth = Number(window.getComputedStyle(el.parentNode).width.replace('px', ''));
        let parentHeight = Number(window.getComputedStyle(el.parentNode).height.replace('px', ''));
        // 获取父元素宽高比例
        let scale = binding.value ? binding.value.scale : parentHeight / parentWidth;
        // 清除元素style值
        el.style = '';
        if (height / width < scale) {
          el.style.height = '100%';
          // 获取图片放入后实际的宽度
          // let imgWidth = Number(window.getComputedStyle(el).width.replace('px', ''));
          let imgWidth = (width * parentHeight) / height;
          el.style.marginLeft = `${(parentWidth - imgWidth) / 2}px`;
        } else if (height / width > scale) {
          el.style.width = '100%';
        } else {
          el.style.width = '100%';
          el.style.height = '100%';
        }
      });
    }
  */

</script>

<style lang="less" scoped>


  .image-item {
    width: 100%;
    height: 100%;
    float: left;
    display: flex;
    overflow: hidden;
    align-items: center;
    justify-content: center;
  }

  .button {
    margin-top: 1rem
  }

  .ant-pro-components-tag-select {
    /deep/ .ant-pro-tag-select .ant-tag {
      margin-right: 24px;
      padding: 0 8px;
      font-size: 14px;
    }
  }

  .ant-pro-pages-list-projects-cardList {
    margin-top: 24px;

    /deep/ .ant-card-meta-title {
      margin-bottom: 4px;
    }

    /deep/ .ant-card-meta-description {
      height: 66px;
      overflow: hidden;
      line-height: 22px;
    }

    .cardItemContent {
      display: flex;
      height: 20px;
      margin-top: 16px;
      margin-bottom: -4px;
      line-height: 20px;

      > span {
        flex: 1 1;
        color: rgba(0, 0, 0, .45);
        font-size: 12px;
      }

      /deep/ .ant-pro-avatar-list {
        flex: 0 1 auto;
      }
    }


  }

  .list-content-item {
    color: black;
    display: inline-block;
    vertical-align: middle;
    font-size: 14px;
    margin-left: 40px;

    span {
      line-height: 20px;
    }

    p {
      margin-top: 4px;
      margin-bottom: 0;
      line-height: 22px;
    }
  }

</style>
