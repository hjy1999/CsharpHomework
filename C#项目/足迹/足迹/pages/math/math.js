// pages/math/math.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    logintimes:1344,
    areas:324,
    alarea:" 图书馆",
    citys:21,
    country:2,
    foods:56,
    sceneries:32,
    palyareas:12,
    markets:23,
    suggestion:"最近运动有点少噢，记得多多运动呀。"
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var app = getApp()
    var that=this
    that.setData({
      areas:app.data.test
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
    var app = getApp()
    var that = this
    that.setData({
      areas: app.data.test
    })
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