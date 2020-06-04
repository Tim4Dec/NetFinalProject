import api from './index'
import { axios } from '@/utils/request'
import Qs from 'qs'

export function login(data) {
  return axios({
    url: 'User/Login',
    method: 'post',
    data: JSON.stringify(data),
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}

export function register(data) {
  return axios({
    url: 'User/Register',
    method: 'post',
    data: JSON.stringify(data),
    headers: {
      'Content-Type': 'application/json;charset=UTF-8'
    }
  })
}

export function getInfo(data) {
  console.log("small get infos")
  return axios({
    url: '/user/myInfos',
    method: 'post',
    data: Qs.stringify(data),
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })
}

export function logout() {
  return axios({
    url: '/user/loginOut',
    method: 'post',
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
  })

}

export function getSmsCaptcha (parameter) {
  return axios({
    url: 'User/Sms',
    method: 'post',
    data: parameter
  })
}

export function verifyName (data) {
  return axios({
    url: 'User/Verify?name=' + data,
    method: 'post',
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded'
    }
    //data: parameter
  })
}