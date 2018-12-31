// pages/intext/text.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    focus: false,
    essay:"",
    mood:"",
    locatitle:"",
    date:"12/29"
    
  },
  bindTextAreaBlur: function (e) {
    console.log(e.detail.value)
    var that=this;
    that.setData({
      essay : e.detail.value
    });
    

  },
  bindTextAreaBlu: function (e) {
    console.log(e.detail.value)
    var that = this;
    that.setData({
      mood: e.detail.value
    });


  },
  back:function(){
    var that=this;
    if(that.data.essay!=""&&that.data.mood!=""){
      wx.showToast({
        title: '成功',
        icon: 'success',
        duration: 2000
      })
      var app = getApp()
      var i= app.data.test
      i=i+1
      app.data.test=i
      wx.request({
        url: 'https://footstepapi.chinacloudsites.cn/api/users/Get?&data=' + that.data.date + '&mood=' + that.data.mood +'&things='+that.data.essay,
        method: 'GET',
        data: {
        },
        header: {
          'content-type': 'application/json'  //这里注意POST请求content-type是小写，大写会报错  
        },
        success: function (res) {
          console.log(res.data)
          console.log('成功')
          // that.setData({ //这里是修改data的值  
          //   things: res.data //test等于服务器返回来的数据  
          // });
          // console.log(res.data)
        }
      });
    }
    else{
      wx.showToast({
        title: '信息不能为空',
        icon: 'none',
        duration: 2000
      })
    }
   
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var that =this
    var app =getApp()
    that.setData({
      locatitle:app.data.locatitle
    })

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

  }
})