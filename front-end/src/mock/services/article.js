import Mock from 'mockjs2'

const allArticle = (data) => {
  let articleList={
    '1': [
      {
        id: "10001",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=29db74ee61fb0ef04a6d501b14f31bfd&imgtype=0&src=http%3A%2F%2Fi1.sinaimg.cn%2Fedu%2F2012%2F0917%2FU3238P42DT20120917165029.jpg',
        article_title: '感恩是对自己最好的回馈',
        content: '只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。'
      },
      {
        id: "10002",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=29db74ee61fb0ef04a6d501b14f31bfd&imgtype=0&src=http%3A%2F%2Fi1.sinaimg.cn%2Fedu%2F2012%2F0917%2FU3238P42DT20120917165029.jpg',
        article_title: '世上最深的恶意，是劝你再来一把',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。花一万能收回来的，叫投资，花完一万又一万，是败家。花一万能收回来的，叫投资，花完一万又一万，是败家。花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },
      {
        id: "10003",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=29db74ee61fb0ef04a6d501b14f31bfd&imgtype=0&src=http%3A%2F%2Fi1.sinaimg.cn%2Fedu%2F2012%2F0917%2FU3238P42DT20120917165029.jpg',
        article_title: '最好的亲子教育',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },
      {
        id: "10004",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=caa2239fed679f16101c819131d7fa72&imgtype=0&src=http%3A%2F%2Fwww.rui-ling.com%2Fupload%2F2015-07%2F15071914546329.jpg',
        article_title: '金鱼一代，手机改变人们',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },
      {
        id: "10005",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=846ce529363823cfaf3a1db5ea0fdb44&imgtype=0&src=http%3A%2F%2Fpic.makepolo.net%2Fnews%2Fallimg%2F20161224%2F1482590070082406.jpg',
        article_title: '为何在绝望之际',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },
      {
        id: "10006",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=846ce529363823cfaf3a1db5ea0fdb44&imgtype=0&src=http%3A%2F%2Fpic.makepolo.net%2Fnews%2Fallimg%2F20161224%2F1482590070082406.jpg',
        article_title: '做个吃瓜群众没什么不好',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },
      {
        id: "10007",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=846ce529363823cfaf3a1db5ea0fdb44&imgtype=0&src=http%3A%2F%2Fpic.makepolo.net%2Fnews%2Fallimg%2F20161224%2F1482590070082406.jpg',
        article_title: '心有猛虎，细嗅蔷薇。',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },
      {
        id: "10008",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=846ce529363823cfaf3a1db5ea0fdb44&imgtype=0&src=http%3A%2F%2Fpic.makepolo.net%2Fnews%2Fallimg%2F20161224%2F1482590070082406.jpg',
        article_title: '心有猛虎，细嗅蔷薇。',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      }


    ],
    '2':[
      {
        id: "10009",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=846ce529363823cfaf3a1db5ea0fdb44&imgtype=0&src=http%3A%2F%2Fpic.makepolo.net%2Fnews%2Fallimg%2F20161224%2F1482590070082406.jpg',
        article_title: '心有猛虎，细嗅蔷薇。',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },
      {
        id: "10009",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=846ce529363823cfaf3a1db5ea0fdb44&imgtype=0&src=http%3A%2F%2Fpic.makepolo.net%2Fnews%2Fallimg%2F20161224%2F1482590070082406.jpg',
        article_title: '心有猛虎，细嗅蔷薇。',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },
      {
        id: "10009",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=846ce529363823cfaf3a1db5ea0fdb44&imgtype=0&src=http%3A%2F%2Fpic.makepolo.net%2Fnews%2Fallimg%2F20161224%2F1482590070082406.jpg',
        article_title: '心有猛虎，细嗅蔷薇。',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },
      {
        id: "10009",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=846ce529363823cfaf3a1db5ea0fdb44&imgtype=0&src=http%3A%2F%2Fpic.makepolo.net%2Fnews%2Fallimg%2F20161224%2F1482590070082406.jpg',
        article_title: '心有猛虎，细嗅蔷薇。',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      },

      {
        id: "10010",
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866029&di=846ce529363823cfaf3a1db5ea0fdb44&imgtype=0&src=http%3A%2F%2Fpic.makepolo.net%2Fnews%2Fallimg%2F20161224%2F1482590070082406.jpg',
        article_title: '心有猛虎，细嗅蔷薇。',
        content: '花一万能收回来的，叫投资，花完一万又一万，是败家。'
      }


    ]
  }

  return {
    data: {
      totalPage:50,
      articleList:articleList[data.body]
    }
  }
}

const articleDetail=(data)=>{
  let articleShow = {
    '10001':
      {
        title:'感恩是对自己最好的回馈',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'张琪',
        content:'只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。',
        issuingTime:'2019.11.11'
      },
    '10002':
      {
        title:'世上最深的恶意，是劝你再来一把',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'闫雪原',
        content:'只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。',
        issuingTime:'2019.11.11'
      },
    '10003':
      {
        title:'最好的亲子教育',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'陈恬恬',
        content:'只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。',
        issuingTime:'2019.11.11'
      },
    '10004':
      {
        title:'4金鱼一代，手机改变人们',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'郁佳麟',
        content:'只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。',
        issuingTime:'2019.11.11'
      },
    '10005':
      {
        title:'5金鱼一代，手机改变人们',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'郁佳麟',
        content:'只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。',
        issuingTime:'2019.11.11'
      },
    '10006':
      {
        title:'6金鱼一代，手机改变人们',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'郁佳麟',
        content:'只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。',
        issuingTime:'2019.11.11'
      },
    '10007':
      {
        title:'7金鱼一代，手机改变人们',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'郁佳麟',
        content:'最近，在停止冥想很长一段时间之后，我又重新开始练习冥想了。\n' +
          '\n' +
          '你或许会问：当初为什么会停止冥想呢？\n' +
          '\n' +
          '原因是，我认为自己已经有非常好的自我觉察力和情绪调节能力了，平时也几乎不会怎么受到情绪的困扰，所以感觉自己不需要冥想了。\n' +
          '\n' +
          '可为什么现在又重新开始冥想了呢？这其实和我前一段时间的状态，以及一位朋友给我的启发有关：\n' +
          '\n' +
          '过去这几个月，我都在忙着写第二本书。就在书稿快要完成的时候，我突然感觉自己整个人的状态都特别不好，大脑总是昏昏沉沉的，打不起精神，晚上睡眠质量也不好，入睡困难，而且经常半夜醒来。\n' +
          '\n' +
          '正巧那个时候我遇到了一个很久不见的朋友，我问他最近在忙些什么，他告诉我说，他今年给自己定的主题就只有两个字——放松。\n' +
          '\n' +
          '这个答案也太让我出乎意料了！我问他怎么会想到定这样一个主题。他说自己之前太焦虑了，以至于身体一直处于亚健康状态，经过半年的放松，他现在已经恢复到一个很好的状态了。紧接着，我又问了一下他的放松方法，他说他用的就是正念的方法。\n' +
          '\n' +
          '听完这些，我立马联想到了自己。我心想，我最近状态那么不好，是不是就是因为精神压力过大，又没有让大脑得到很好的放松呢？\n' +
          '\n' +
          '为了检验这种猜想，我暂停了几天的工作，并利用呼吸练习和身体扫描来帮助自己放松。没想到几天之后，我身上那些疲劳感真的都消失了。\n' +
          '\n' +
          '这个时候，我才意识到，原来自己一直处于慢性压力之中却不自知。好在我对神经科学有一定的了解，也就很快明白了为什么正念冥想是减压和放松的最佳方法。于是，我决定重新养成冥想的习惯。\n' +
          '\n' +
          '经过这段时间的练习，我越来越意识到正念的价值和重要性。所以，今天这篇文章，我就打算和大家聊聊放松这件事情，以及正念冥想背后的减压原理。\n' +
          '\n' +
          '01\n' +
          '  大脑的紧张与放松\n' +
          '\n' +
          '想要理解放松，我们就不得不说到放松的对立面——紧张。\n' +
          '\n' +
          '紧张和放松，代表的其实是大脑神经系统的两种不同状态，而大脑之所以有这两种不同的状态，是为了实现两种重要的功能：白天工作，和夜晚修复。\n' +
          '\n' +
          '大家可能都知道，我们身体的所有器官，都是由自主神经控制的。\n' +
          '\n' +
          '自主神经分为「交感神经」和「副交感神经」。\n' +
          '\n' +
          '交感神经是「白天」的神经，「活动」的神经。副交感神经是「夜晚」的神经、「休息」的神经。\n' +
          '\n' +
          '白天，当交感神经处于主导地位时，大脑和身体便会释放去甲肾上腺素、肾上腺素和皮质醇，它们被统称为压力激素。',
        issuingTime:'2019.11.11'
      },
    '10008':
      {
        title:'8金鱼一代，手机改变人们',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'郁佳麟',
        content:'只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。',
        issuingTime:'2019.11.11'
      },
    '10009':
      {
        title:'9金鱼一代，手机改变人们',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'郁佳麟',
        content:'只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。',
        issuingTime:'2019.11.11'
      },
    '10010':
      {
        title:'10金鱼一代，手机改变人们',
        articleIMG: 'https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1575289866030&di=6916619e37b14879113f40a37c9f965c&imgtype=0&src=http%3A%2F%2Fwww.fstth.com%2Fuserfiles%2Fimage%2Fv2-02fbb3e29d7b7f833db04061914631e8_b.jpg',
        author:'郁佳麟',
        content:'只有感恩的去给与，感恩的去接受，带着爱与被爱的感知，才能真正收获感恩。感恩是对自己的奖赏。',
        issuingTime:'2019.11.11'
      },

  }
  return{
    data:{
      articleShow:articleShow[data.body]
    }
  }
}
Mock.mock(/\/article\/allArticle/, 'post', allArticle);
Mock.mock(/\/article\/articleDetail/, 'post', articleDetail);
