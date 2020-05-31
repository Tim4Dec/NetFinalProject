import {axios} from '@/utils/request'
import Qs from 'qs'

const api = {
  allTest: '/psytest',
  testDetail: '/psytest/certain',
};

export default api

export function getTestList(data) {
  return axios({
    url: api.allTest,
    method: 'post',
    data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }

  })
}

export function getTestDetail(data) {
  return axios({
    url: api.testDetail,
    method: 'post',
    data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })
}

