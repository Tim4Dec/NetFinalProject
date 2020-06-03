<template>

  <div>
    <a-row :gutter="24">
      <a-col :xl="24" :lg="24" :md="24" :sm="24" :xs="24">

        <!--首页横幅-->
        <a-carousel arrows autoplay>
          <!--左按钮-->
          <div
            slot="prevArrow"
            slot-scope="props"
            class="custom-slick-arrow"
            style="left: 10px;zIndex: 1"
          >
            <a-icon type="left-circle"/>
          </div>
          <!--右按钮-->
          <div slot="nextArrow" slot-scope="props" class="custom-slick-arrow" style="right: 10px">
            <a-icon type="right-circle"/>
          </div>
          <!--滚动图片-->
          <router-link :to="{name:'homepage'}" >
            <img src="../../assets/bg05.jpg" alt="P2" class="carousel-img">
          </router-link>
          <router-link :to="{name:'homepage'}" >
            <img src="../../assets/bg06.jpg" alt="P2" class="carousel-img">
          </router-link>
          <router-link :to="{name:'homepage'}" >
            <img src="../../assets/bg13.jpg" alt="P3" class="carousel-img">
          </router-link>
          <router-link :to="{name:'homepage'}" >
            <img src="../../assets/bg11.jpg" alt="P2" class="carousel-img">
          </router-link>
          <router-link :to="{name:'homepage'}" >
            <img src="../../assets/bg02.png" alt="P2" class="carousel-img">
          </router-link>

          <!--滚动招聘结束-->
        </a-carousel>


        <!--发现新鲜事-->
        <a-card
          class="project-list"
          style="margin-bottom: 24px; margin-top: 0px"
          :bordered="false"
          title="发现新鲜事"
          :body-style="{ padding: 0 }">
          <a-card>
            <a-row :gutter="24">
              <a-col :md="24" :lg="6">
                <a-card hoverable>
                  <img
                    alt="校园招聘"
                    src="https://s1.ax1x.com/2020/06/03/tdzZKP.jpg"
                    slot="cover"
                  />
                  <router-link :to="{name: 'ArticleList'}" active-class="active">
                    <a-card-meta
                      title="校园招聘"
                      description="海量HC等你来！点击浏览最新资讯">
                    </a-card-meta>
                  </router-link>
                </a-card>
              </a-col>
              <a-col :md="24" :lg="6">
                <a-card hoverable>
                  <img
                    alt="通知公告"
                    src="https://s1.ax1x.com/2020/06/03/tw9TMR.jpg"
                    slot="cover"
                  />
                  <router-link :to="{name: 'NoteList'}" active-class="active">
                    <a-card-meta
                      title="通知公告"
                      description="点击查看最新的通知">
                    </a-card-meta>
                  </router-link>
                </a-card>
              </a-col>
              <a-col :md="24" :lg="6">
                <a-card hoverable>
                  <img
                    alt="交流天地"
                    src="https://s1.ax1x.com/2020/06/03/tw97s1.jpg"
                    slot="cover"
                  />
                  <router-link :to="{name: 'chat'}" active-class="active">
                    <a-card-meta
                      title="交流天地"
                      description="分享你的职场见闻和疑惑">
                    </a-card-meta>
                  </router-link>
                </a-card>
              </a-col>
              <a-col :md="24" :lg="6">
                <a-card hoverable>
                  <img
                    alt="个人中心"
                    src="https://s1.ax1x.com/2020/06/03/tw9Hqx.jpg"
                    slot="cover"
                  />
                  <router-link :to="{name: 'myPage'}" active-class="active">
                    <a-card-meta
                      title="个人中心"
                      description="管理你的个人信息">
                    </a-card-meta>
                  </router-link>
                </a-card>
              </a-col>
            </a-row>
          </a-card>
        </a-card>
      </a-col>

    </a-row>
  </div>

</template>

<script>
  import {timeFix} from '@/utils/util'
  import {mapGetters} from 'vuex'

  import {PageView} from '@/layouts'
  import HeadInfo from '@/components/tools/HeadInfo'
  import {Radar} from '@/components'

  //import {getRoleList, getServiceList} from '@/api/manage'

  const DataSet = require('@antv/data-set')

  export default {
    name: 'Homepage',
    components: {
      PageView,
      HeadInfo,
      Radar
    },
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

      }
    },
    computed: {
      userInfo() {
        return this.$store.getters.userInfo
      }
    },
    created() {
      this.user = this.userInfo
      this.avatar = this.userInfo.avatar
/*
      getRoleList().then(res => {
        console.log('workplace -> call getRoleList()', res)
      })

      getServiceList().then(res => {
        console.log('workplace -> call getServiceList()', res)
      })
*/
    },
  }
</script>

<style  scoped>

  /*横幅图片格式*/
  .carousel-img{
    align:middle;
    margin: 0 auto;
  }


  /* 首页横幅 */
  .ant-carousel>>>.slick-slide {
    text-align: center;
    height: 320px;
    line-height: 160px;
    background: #fff;
    overflow: hidden;
  }

  .ant-carousel>>> .custom-slick-arrow {
    width: 25px;
    height: 25px;
    font-size: 25px;
    color: #fff;
    background-color: #1890FF;
    opacity: 0.5;
  }

  .ant-carousel >>> .custom-slick-arrow:before {
    display: none;
  }

  .ant-carousel >>> .custom-slick-arrow:hover {
    opacity: 0.5;
  }

  .ant-carousel >>> .slick-slide h3 {
    color: #fff;
  }


</style>
