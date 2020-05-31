import {axios} from '@/utils/request'
import Qs from 'qs'
const api = {
  allArticle: '/article',
  articleDetail: '/article/certain',
}

export default api

export function getArticle(data) {
  return axios({
    url: api.allArticle,
    method: 'post',
    // data: data,
    data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })
}

export function getArticleDetail(data) {
  return axios({
    url: api.articleDetail,
    method: 'post',
    data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })
}

