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
          <!--个人主页-->
          <router-link :to="{name:'myPage'}" >
            <img src="../../assets/bg1.jpg" alt="P1" class="carousel-img">
          </router-link>
          <!--心理测试-->
          <router-link :to="{name:'ArticleList'}" >
            <img src="../../assets/bg2.jpg" alt="P2" class="carousel-img">
          </router-link>
          <!--科普天地-->
          <router-link :to="{name:'Psytest'}" >
            <img src="../../assets/bg3.jpg" alt="P3" class="carousel-img">
          </router-link>
          <!---->
          <router-link :to="{name:'treehole'}" >
            <img src="../../assets/bg4.jpg" alt="P4" class="carousel-img">
          </router-link>
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
                    alt="科普天地"
                    src="https://res.cloudinary.com/dwjmbwy0f/image/upload/v1577049809/psyche/175F1A13E92EFC616B3E7093E9F1C5DD_vu0xks.jpg"
                    slot="cover"
                  />
                  <router-link :to="{name: 'ArticleList'}" active-class="active">
                    <a-card-meta
                      title="校园招聘"
                      description="点击浏览最新资讯">
                    </a-card-meta>
                  </router-link>
                </a-card>
              </a-col>
              <a-col :md="24" :lg="6">
                <a-card hoverable>
                  <img
                    alt="通知栏"
                    src="https://res.cloudinary.com/dwjmbwy0f/image/upload/v1577049826/psyche/17C958B070F0A6A8B2BFAA268F1C917C_ujnsmx.jpg"
                    slot="cover"
                  />
                  <router-link :to="{name: 'NoteList'}" active-class="active">
                    <a-card-meta
                      title="通知公告"
                      description="点击查看通知">
                    </a-card-meta>
                  </router-link>
                </a-card>
              </a-col>
              <a-col :md="24" :lg="6">
                <a-card hoverable>
                  <img
                    alt="心理咨询"
                    src="https://res.cloudinary.com/dwjmbwy0f/image/upload/v1577049660/psyche/396F3C7323E081617808A18D72B0F5DE_ohkxre.jpg"
                    slot="cover"
                  />
                  <router-link :to="{name: 'teacher'}" active-class="active">
                    <a-card-meta
                      title="交流天地"
                      description="点击预约心理医生">
                    </a-card-meta>
                  </router-link>
                </a-card>
              </a-col>
              <a-col :md="24" :lg="6">
                <a-card hoverable>
                  <img
                    alt="心理测试"
                    src="https://res.cloudinary.com/dwjmbwy0f/image/upload/v1577050086/psyche/2A8FD3AD7E4B45B1E602453CE9EB6782_wcqcz7.jpg"
                    slot="cover"
                  />
                  <router-link :to="{name: 'TestList'}" active-class="active">
                    <a-card-meta
                      title="个人中心"
                      description="测测你的内心">
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

  import {getRoleList, getServiceList} from '@/api/manage'

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

      getRoleList().then(res => {
        console.log('workplace -> call getRoleList()', res)
      })

      getServiceList().then(res => {
        console.log('workplace -> call getServiceList()', res)
      })
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
    background: #364d79;
    overflow: hidden;
  }

  .ant-carousel>>> .custom-slick-arrow {
    width: 25px;
    height: 25px;
    font-size: 25px;
    color: #fff;
    background-color: rgba(31, 45, 61, 0.11);
    opacity: 0.3;
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
