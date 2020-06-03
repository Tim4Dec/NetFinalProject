<template>
  <div class="user-wrapper">
    <div class="content-box">
      <a href="https://github.com/Tim4Can/Psyche" target="_blank">
        <span class="action">
          <a-icon type="github"></a-icon>
        </span>
      </a>


      <a-dropdown>
        <span class="action ant-dropdown-link user-dropdown-menu">
          <a-avatar class="avatar" size="small" :src="userInfo.avatar"/>
          <span>{{userInfo.nickname}} </span>
        </span>
        <a-menu slot="overlay" class="user-dropdown-menu-wrapper">
          <a-menu-item key="0">
            <router-link :to="{ name: 'myPage' }">
              <a-icon type="user"/>
              <span>个人中心</span>
            </router-link>
          </a-menu-item>
          <a-menu-divider/>
          <a-menu-item key="3">
            <a href="javascript:;" @click="handleLogout">
              <router-link :to="{ name: 'login' }">
              <a-icon type="logout"/>
              <span>退出登录</span>
              </router-link>
            </a>
          </a-menu-item>
        </a-menu>
      </a-dropdown>
    </div>
  </div>
</template>

<script>
  import NoticeIcon from '@/components/NoticeIcon'
  import { mapActions, mapGetters } from 'vuex'
  export default {
    name: 'UserMenu',
    components: {
      NoticeIcon
    },
      computed: {
          userInfo() {
              return this.$store.getters.userInfo
          }
      },
    methods: {
      ...mapActions(['Logout']),
      ...mapGetters(['nickname', 'avatar']),


      handleLogout () {
        const that = this

        this.$confirm({
          title: '提示',
          content: '真的要退出登录吗 ?',
          onOk () {
              //this.$router.push({name:'login'})
            return that.Logout({}).then(() => {
              window.location.reload()
            }).catch(err => {
              that.$message.error({
                title: '错误',
                description: err.message
              })
            })
          },
          onCancel () {
          }
        })
      }
    }
  }
</script>
