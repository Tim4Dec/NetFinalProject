import Mock from 'mockjs2'

const allTest = (data) => {
  let testList={
    '1': [
      {
        id: "10001",
        title: '1本站开放啦！！！',
        description: '感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈',
        url: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=29db74ee61fb0ef04a6d501b14f31bfd&imgtype=0&src=http%3A%2F%2Fi1.sinaimg.cn%2Fedu%2F2012%2F0917%2FU3238P42DT20120917165029.jpg'
      },
      {
        id: "10002",
        title: '1本站开放啦！！！',
        description: '感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈',
        url: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=29db74ee61fb0ef04a6d501b14f31bfd&imgtype=0&src=http%3A%2F%2Fi1.sinaimg.cn%2Fedu%2F2012%2F0917%2FU3238P42DT20120917165029.jpg'
      },
      {
        id: "10003",
        title: '1本站开放啦！！！',
        description: '感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈',
        url: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=29db74ee61fb0ef04a6d501b14f31bfd&imgtype=0&src=http%3A%2F%2Fi1.sinaimg.cn%2Fedu%2F2012%2F0917%2FU3238P42DT20120917165029.jpg'
      },
      {
        id: "10004",
        title: '1本站开放啦！！！',
        description: '感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈',
        url: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=29db74ee61fb0ef04a6d501b14f31bfd&imgtype=0&src=http%3A%2F%2Fi1.sinaimg.cn%2Fedu%2F2012%2F0917%2FU3238P42DT20120917165029.jpg'
      },
      {
        id: "10005",
        title: '1本站开放啦！！！',
        description: '感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈感恩是对自己最好的回馈',
        url: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=29db74ee61fb0ef04a6d501b14f31bfd&imgtype=0&src=http%3A%2F%2Fi1.sinaimg.cn%2Fedu%2F2012%2F0917%2FU3238P42DT20120917165029.jpg'
      },

    ]
  }
  return {
    data:{
      totalPage:50,
      testList:testList[data.body]
    }
  }
}

const testDetail = (data) => {
  let testShow = {
    0:
      {
        testId:'10001',
        questionId:0,
        question: '000你暴躁吗？',
        choiceA: '一直很暴躁呢^_^',
        choiceB: '前端不传参',
        choiceC: '我也很绝望啊！！',
      },
    1:
      {
        testId:'10001',
        questionId:2,
        question: '2你睡了吗？',
        choiceA: '222一直很暴躁呢^_^',
        choiceB: '222前端不传参',
        choiceC: '222我也很绝望啊！！',
      },
    2:
      {
        testId:'10001',
        questionId:3,
        question: '你快乐吗？',
        choiceA: '一直很快乐呢^_^',
        choiceB: '前端不传参',
        choiceC: '我也很快乐啊！！',
      },
    3:
      {
        testId:'10001',
        questionId:-1,
        question: '你忧伤吗？',
        choiceA: '一直很忧桑呢^_^',
        choiceB: '前端不传参',
        choiceC: '我也很忧桑啊！！',
      },

  }
  return {
    data: {
      testShow: testShow[data.body]
    }
  }
}

Mock.mock(/\/psytest\/allTest/, 'post', allTest);
Mock.mock(/\/psytest\/testDetail/, 'post', testDetail);
