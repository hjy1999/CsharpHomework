// pages/text/text.js
Page({

  /**
   * 页面的初始数据
   */
  data: { 
    year: "2018",
    month: "12",
    day: "29",
    date:[],
    mood:[],
    things:[],
    length:""
    // more :[
    //   {
    //     date:"12/12",
    //   mood:"宁",
    //     things:"等闲若得东风顾,",
      
    //    },
    //     {
    //     date: "12/13",
    //     mood: "负",
    //       things: "不负春光不负卿。",
    //   },
    //   {
    //     date: "12/14",
    //     mood: "如",
    //     things: "春浓怎奈风月轻,",
    //   },
    //   {
    //     date: "12/15",
    //     mood: "来",
    //     things: "即来尘世可无情?",
    //   },
    //   {
    //     date: "12/16",
    //     mood: "不",
    //     things: "待到春暖花开，",
    //   },
    //   {
    //     date: "12/17",
    //     mood: "负",
    //     things: "执手共漫花枝下，",
    //   },
    //   {
    //     date: "12/18",
    //     mood: "卿",
    //     things: "不负春光不负卿。",
    //   }
    // ]
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var that = this //创建一个名为that的变量来保存this当前的值  
    var mod =[]
    var dat = []
    var thing = []
    wx.request({
      url: 'https://footstepapi.chinacloudsites.cn/api/users',
      method: 'Get',
      data: {
          //这里是发送给服务器的参数（参数名：参数值）  
      },
      header: {
        'content-type': 'application/x-www-form-urlencoded'  //这里注意POST请求content-type是小写，大写会报错  
      },
      success: function (res) {
       that.setData({
         length:res.data.length
       });
        console.log(res.data)
        for (var i = 0; i < res.data.length; i++) {
          mod[i] = res.data[i][1]
          dat[i] = res.data[i][0]
          thing[i] = res.data[i][2]
         
        }
          that.setData({ //这里是修改data的值  
            mood: mod //test等于服务器返回来的数据  
          });
          that.setData({ //这里是修改data的值  
            date: dat //test等于服务器返回来的数据  
          });
          that.setData({ //这里是修改data的值  
            things: thing //test等于服务器返回来的数据  
          });
      }

    }); 
    
        
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  },
  onTap: function () {
     var that = this //创建一个名为that的变量来保存this当前的值
  //   wx.request({
  //     url: 'https://footstepapi.chinacloudsites.cn/api/users/'+that.data.day,
  //     method: 'GET',
  
  //     data:  {
  //         id:123456
  //     },          
  //     header: {
  //       'content-type': 'application/json'  //这里注意POST请求content-type是小写，大写会报错  
  //     },
  //     success: function (res) {
  //       console.log(res.data)
  //       console.log('成功')
  //       // that.setData({ //这里是修改data的值  
  //       //   things: res.data //test等于服务器返回来的数据  
  //       // });
  //       // console.log(res.data)
  //     }
  //   });
   }
})