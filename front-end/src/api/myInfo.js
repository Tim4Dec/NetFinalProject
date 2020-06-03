import {axios} from "@/utils/request";

const api = {
  mySpeech: 'User/Speech',
  myLike: '/myInfo/myLike',
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

export function getMyLike (data) {
  return axios({
    url: api.myLike,
    method: 'post',
    data: data,
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}