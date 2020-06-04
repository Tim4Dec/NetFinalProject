/* eslint-disable */
import {UserLayout, BasicLayout, RouteView, BlankLayout} from '@/layouts'
import {recruit, consult} from '@/core/icons'

export const asyncRouterMap = [
{
  path: '/',
  name: 'index',
  component: BasicLayout,
  meta: {title: '首页'},
  redirect: '/homepage',
  children: [
    {
      path: '/homepage',
      name: 'homepage',
      meta: {title: '首页', keepAlive: true, icon: 'home'},
      component: () => import( '@/views/user/Homepage' ),
    },


    //校园招聘
    {
      path: '/article/list',
      name: 'ArticleList',
      hidden: false,
      component: () => import('@/views/article/ArticleList'),
      meta: {
        title: '校园招聘', keepAlive: true, icon: recruit
      }
    },
    {
      path: '/article/detail/:id',
      name: 'ArticleDetail',
      hidden: true,
      component: () => import('@/views/article/ArticleDetail'),
      meta: {
        title: '招聘详情', keepAlive: false, icon: recruit,
      }
    },


    //通知公告
    {
      path: '/note/list',
      name: 'NoteList',
      hidden: false,
      component: () => import('@/views/note/NoteList'),
      meta: {
        title: '通知公告', keepAlive: true, icon: 'bell'
      }
    },
    {
      path: '/note/detail/:id',
      name: 'NoteDetail',
      hidden: true,
      component: () => import('@/views/note/NoteDetail'),
      meta: {
        title: '通知详情', keepAlive: false, icon: 'bell',
      }
    },


    //交流天地
    /*
    {
      path: '/chat',
      name: 'chat',
      redirect: '/chat/Post',
      component: RouteView,
      meta: {title: '交流天地', keepAlive: true, icon: consult},
      children: [
        {
          path: '/chat/post',
          name: 'post',
          component: () => import( '@/views/chat/Post' ),
          meta: {
            title: '帖子', keepAlive: false //, icon: consult
          }
        },
        {
          path: '/chat/detail/:id',
          name: 'postDetail',
          hidden: true,
          component: () => import( '@/views/chat/PostDetail' ),
          meta: {
            title: '详情', keepAlive: false, icon: consult
          }
        }
      ]
    },
*/
    {
      path: '/chat',
      name: 'chat',
      hidden: false,
      component: () => import('@/views/chat/Post'),
      meta: {
        title: '交流天地', keepAlive: true, icon: consult
      }
    },
    {
      path: '/chat/detail/:id',
      name: 'postDetail',
      hidden: true,
      component: () => import('@/views/chat/PostDetail'),
      meta: {
        title: '详情', keepAlive: false, icon: consult,
      }
    },



    //个人中心
    {
      path: '/user/MyPage',
      name: 'myPage',
      component: () => import( '@/views/user/MyPage' ),
      meta: {title: '个人中心', keepAlive: true, icon: 'user'}
    },

  ]
},
{
  path: '*', redirect: '/404', hidden: true
}
]

/**
* 基础路由
* @type { *[] }
*/
export const constantRouterMap = [
{
  path: '/user',
  component: UserLayout,
  redirect: '/user/login',
  hidden: true,
  children: [
    {
      path: 'login',
      name: 'login',
      component: () => import(/* webpackChunkName: "user" */ '@/views/user/Login' )
    },
    {
      path: 'register',
      name: 'register',
      component: () => import(/* webpackChunkName: "user" */ '@/views/user/Register')
    },
  ]
},


{
  path: '/test',
  component: BlankLayout,
  redirect: '/test/home',
  children: [
    {
      path: 'home',
      name: 'TestHome',
      component: () => import( '@/views/Home' )
    }
  ]
},

{
  path: '/404',
  component: () => import(/* webpackChunkName: "fail" */ '@/views/exception/404' )
}

]
