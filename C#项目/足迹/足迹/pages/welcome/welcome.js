Page({
  onTap:function(){
   //wx.navigateTo({url:"../posts/post" });
    wx.getSetting({
      success(res) {
        if (!res.authSetting['scope.werun']) {
          wx.authorize({
            werun: 'scope.werun',
            success() {
              // 用户已经同意小程序使用录音功能，后续调用 wx.startRecord 接口不会弹窗询问
              wx.getWeRunData()
            }
          })
        }
        if (!res.authSetting['scope.userLocation']) {
          wx.authorize({
            werun: 'scope.userLocation',
            success() {
              // 用户已经同意小程序使用录音功能，后续调用 wx.startRecord 接口不会弹窗询问
              wx.getLocation()
            }
          })
        }
      }
    })
    wx.switchTab({
      url: '../posts/post'
    })
   
  }

})