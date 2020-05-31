<template>
  <a-row :gutter="24">
    <a-col :xl="24" :lg="24" :md="24" :sm="24" :xs="24">
      <!--老师信息-->
      <a-card
        class="project-list"
        :loading="loading"
        style="margin-bottom: 24px; margin-top: 0px"
        :bordered="true"
        title="科普天地"
        :body-style="{ padding: 0 }">
        <a-card>
          <a-row :gutter="12">
            <!--科普天地-->
            <div class="ant-pro-pages-list-projects-cardList">
              <a-list :loading="loading" :data-source="data" :grid="{ gutter: 12,column: 4 }"
                      :pagination="pagination" >
                <a-list-item slot="renderItem" slot-scope="item">
                  <a-card class="ant-pro-pages-list-projects-card" hoverable :loading="loading"
                          style="margin: 0 5px 0 5px">

<!--                图片裁剪
                    <div class="image-item">
                      <img v-interceptImg slot="cover" :src="item.articleIMG" :alt="item.article_title">
                    </div>
-->

                    <img slot="cover" :src="item.image" :alt="item.title"/>
                    <a-card-meta :title="item.title" style="text-align: center">
                      <template slot="description">
                        <ellipsis :length="70">{{ item.content | ellipsis }}</ellipsis>
                      </template>
                    </a-card-meta>
                    <a-button type="primary" class="cardItemContent" ghost=true>
                      <router-link :to="{ name: 'ArticleDetail', params:{ id: item.id} }">浏览文章</router-link>
                    </a-button>
                  </a-card>
                </a-list-item>
              </a-list>
                <a-pagination @change="onChange" :current="current" :total="totalPage*10" style="text-align: center"/>
            </div>

          </a-row>
        </a-card>
      </a-card>
    </a-col>
  </a-row>

</template>

<script>
  import moment from 'moment'
  import {TagSelect, StandardFormRow, Ellipsis, AvatarList} from '@/components'
  import {getArticle} from '@/api/article'
  import {PageView} from '@/layouts'

  export default {
    components: {
      PageView
    },
    data() {
      return {
        data: [],
        allData: [],
        loading: false,
        current: 1,
        totalPage: '',
      }
    },
    filters: {
      fromNow(date) {
        return moment(date).fromNow()
      },

      /*省略多余描述*/
      ellipsis (value) {
        if (!value) return ''
        if (value.length > 40) {
          return value.slice(0,40) + '······'
        }
        return value
      }

    },
    methods: {
      onChange(current) {
        this.current = current;
        console.log('页码：',this.allData.id)
          getArticle({'pageNum':this.current}).then(response => {
              console.log('点击输出', response)
              this.allData = response.data
              this.loading = false
              this.data = this.allData.content
              this.totalPage = this.allData.totalPages
          })
      },


    },
    mounted(){
        console.log(this.current);
        getArticle({'pageNum':this.current}).then(response => {
            console.log('点击输出', response)
            this.allData = response.data
            this.loading = false
            this.data = this.allData.content
            this.totalPage = this.allData.totalPage
        })
    }
  }



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
    margin-top: 10px;
    margin-left: 10px;
    margin-right: 10px;

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
</style>
