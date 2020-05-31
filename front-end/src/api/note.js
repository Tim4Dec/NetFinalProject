import {axios} from '@/utils/request'
import Qs from 'qs'
const api = {
  allNote: '/announcement',
  noteDetail: '/announcement/noteDetail',
};

export default api

export function getNoteList(data) {
  return axios({
    url: api.allNote,
    method: 'post',
    data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }

  })
}

export function getNoteDetail(data) {
  return axios({
    url: api.noteDetail,
    method: 'post',
    data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })
}

