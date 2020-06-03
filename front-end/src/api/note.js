import {axios} from '@/utils/request'
import Qs from 'qs'
const api = {
  allNote: 'Notice/All',
  noteDetail: 'Notice/Detail',
};

export default api

export function getNoteList(data) {
  console.log(api.allNote + "?page=" + data)
  return axios({
    url: api.allNote + "?page=" + data,
    method: 'post',
    //data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }

  })
}

export function getNoteDetail(data) {
  return axios({
    url: api.noteDetail + "?id=" + data,
    method: 'post',
    data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })
}

