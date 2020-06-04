import { axios } from '@/utils/request'

const api = {
  allPost: 'Speech/All',
  postDetail: 'Speech/Detail',
  deliverSpeech: 'Speech/Deliver',
  deleteSpeech: 'Speech/Delete',
  sendComment: 'Comment/Deliver',
  comment:'Comment/All',
  deleteComment: 'Comment/Delete',
}

export default api

export function getPost (data) {
  return axios({
    url: api.allPost + "?=" + data,
    method: 'post',
    //data: data,
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}

export function postDetail(data) {
  return axios({
    url: api.postDetail + "?id=" + data,
    method: 'post',
    data: data,
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}

export function getComment(data) {
  return axios({
    url: api.comment,
    method: 'post',
    data: JSON.stringify(data),
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}

export function deliverSpeech(data) {
  return axios({
    url: api.deliverSpeech,
    method: 'post',
    data: JSON.stringify(data),
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}

export function deleteSpeech (data) {
  return axios({
    url: api.deleteSpeech + "?id="+ data ,
    method: 'post',
    //data: data,
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}

export function sendComment(data) {
  return axios({
    url: api.sendComment,
    method: 'post',
    data: JSON.stringify(data),
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}

export function deleteComment (data) {
  return axios({
    url: api.deleteComment + "?id="+ data ,
    method: 'post',
    //data: data,
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}