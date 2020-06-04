import {axios} from "@/utils/request";

const api = {
  mySpeech: 'User/Speech',
  myComment: 'User/Comment',
}

export function getMyPost (data) {
  return axios({
    url: api.mySpeech,
    method: 'post',
    data: JSON.stringify(data),
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}

export function getMyComment (data) {
  return axios({
    url: api.myComment,
    method: 'post',
    data: JSON.stringify(data),
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}