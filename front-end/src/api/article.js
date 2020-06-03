import {axios} from '@/utils/request'
import Qs from 'qs'
const api = {
  allArticle: 'Article/All',
  articleDetail: 'Article/Detail',
}

export default api

export function getArticle(data) {
  return axios({
    url: api.allArticle + "?page="+data,
    method: 'post',
    // data: data,
    // data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })
}

export function getArticleDetail(data) {
  return axios({
    url: api.articleDetail + "?id="+data,
    method: 'post',
    //data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })
}

