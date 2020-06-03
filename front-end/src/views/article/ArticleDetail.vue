<template>
  <page-view title="招聘详情">
    <!--回到顶部-->
    <a-back-top></a-back-top>
    <a-back-top id="components-back-top-demo-custom">
      <div class="ant-back-top-inner" style="color: white">UP</div>
    </a-back-top>
    <a-card :bordered="false" :data-source="data" pagination=" ">
      <a-skeleton :loading="loading" active></a-skeleton>

      <!--返回文章列表-->
      <div class="return-button">
        <router-link :to="{name: 'ArticleList'}">
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
        作者：{{ author }} | 发布时间：{{ issuingTime }}
      </h4>
      <br>

      <!--文章内容-->
      <h3 class="comment" style="margin: 20px 70px 20px 70px">
        {{ content }}
      </h3>
      <p style="text-align: center; color:gray">
        <strong>
          ——END——
        </strong>
      </p>
      <!---->

    </a-card>

  </page-view>
</template>

<script>
  import {PageView} from '@/layouts'
  import {getArticleDetail} from "../../api/article"


  export default {
    name: 'articleDetail',
    components: {
      PageView,
    },
    data() {
      return {
        // 加载数据方法 必须为 Promise 对象
        data: [],
        allData: [],
        loading: false,
          title:'',
          author:'',
          content:'',
          issuingTime:'',
        articleID: this.$route.params.id,
      }
    },

    created() {
      this.getDetail()
    },

    methods: {
      getDetail() {
        //getArticleDetail({"id":this.articleID}).then(response => {
        getArticleDetail(this.articleID).then(response => {

          console.log(response)

          this.allData = response.Data;
          this.title = this.allData.title;
          this.author = this.allData.author;
          this.content = this.allData.content;
          this.issuingTime = this.allData.time.split("T")[0];

          console.log(this.allData);
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
