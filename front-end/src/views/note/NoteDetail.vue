<template>
  <page-view title="通知详情">

    <!--回到顶部-->
    <a-back-top id="components-back-top-demo-custom">
      <div class="ant-back-top-inner" style="color: white">UP</div>
    </a-back-top>
    <a-card :bordered="false" :data-source="data" pagination=" ">
      <a-skeleton :loading="loading" active></a-skeleton>

      <!--返回文章列表-->
      <div class="return-button">
        <router-link :to="{name: 'NoteList'}">
          <a-button type="primary">
            <a-icon type="left"/>返回
          </a-button>
        </router-link>
      </div>

      <!-- 文章标题 -->
      <h1 style="text-align: center">
        <strong>
          {{ title }}
        </strong>
      </h1>
      <!--作者时间-->
      <h4 style="text-align: center">
        发送时间：{{ issuingTime }}
      </h4>
      <br>
      <!--文章内容-->

      <p class="comment" style="margin: 20px 70px 20px 70px">
        {{ content }}
      </p>
      <p style="text-align: center; color:gray">
        <strong>
          ——消息已读完——
        </strong>
      </p>
      <!---->

    </a-card>

  </page-view>
</template>

<script>
  import {PageView} from '@/layouts'
  import {getNoteDetail} from "../../api/note"


  export default {
    name: 'noteDetail',
    components: {
      PageView,
    },
    data() {
      return {
        // 加载数据方法 必须为 Promise 对象
        data: [],
        allData: [],
        loading: false,

        noteID: this.$route.params.id,
      }
    },

    created() {
      this.getDetail()
    },

    methods: {
      getDetail() {
        getNoteDetail(this.noteID).then(response => {
          console.log(this.noteID);
          console.log(response)

          this.data = response.Data;
          this.title = this.data.title;
          this.author = this.data.author;
          this.content = this.data.content;
          this.issuingTime = this.data.time;

          console.log(this.data);
        })
      }

    }
  }


</script>

<style lang="less" scoped>
  .title {
    color: rgba(0, 0, 0, .85);
    font-size: 16px;
    font-weight: 500;
    margin-bottom: 16px;
  }

  .comment{
    white-space:pre-wrap;
  }

  #components-back-top-demo-custom .ant-back-top {
    bottom: 100px;
  }
  #components-back-top-demo-custom .ant-back-top-inner {
    height: 40px;
    width: 40px;
    line-height: 40px;
    border-radius: 40px;
    background-color: #1088e9;
    color: #fff;
    text-align: center;
    font-size: 20px;
  }
</style>
