var bmap = require('../../libs/bmap-wx.js');
var wxMarkerData = [];
Page({
  data: {
    markers: [],
    latitude: '',
    longitude: '',
    placeData: {},
    weatherData: '',
    latitud:'',
    longitud:'',
    step:'12321',
    si:'武汉大学',
    essat:''
  },
  makertap: function (e) {
    var that = this;
    var id = e.markerId;
    that.showSearchInfo(wxMarkerData, id);
    //that.changeMarkerColor(wxMarkerData, id);
  },
  onLoad: function () {
    var that = this;
    // 新建百度地图对象 
    var BMap = new bmap.BMapWX({
      ak: '0C0q7mvzf1ulOrpTQ1mXQqcOIemC8lYO'
    });
    var fail = function (data) {
      console.log(data)
    };
    wx.getLocation({
      type: 'wgs84',
      success(res) {
        var latitud = res.latitude
        var longitud = res.longitude
        var speed = res.speed
        var accuracy = res.accuracy
        that.setData({
          latitud: latitud
        });
        that.setData({
          longitud:longitud
        });
      }
    })
    var success = function (data) {
      wxMarkerData = data.wxMarkerData;
      console.log(wxMarkerData)
      console.log(that.data.latitud)
      console.log(that.data.longitud)
      that.setData({
        markers: wxMarkerData
        
      });
      that.setData({
        latitude: wxMarkerData[0].latitude
      });
      that.setData({
        
        longitude: wxMarkerData[0].longitude
      });
    }
    // 发起POI检索请求 
    BMap.search({
      "query": that.data.si,
      fail: fail,
      success: success,
      // 此处需要在相应路径放置图片文件 
      iconPath: '../../photo/marker_red.png',
      // 此处需要在相应路径放置图片文件 
      iconTapPath: '../../photo/marker_yellow.png'
    });
    var that = this;
    // 新建百度地图对象 
    var BMap = new bmap.BMapWX({
      ak: '0C0q7mvzf1ulOrpTQ1mXQqcOIemC8lYO'
    });
    var fail = function (data) {
      console.log(data)
    };
    var success = function (data) {
      var weatherData = data.currentWeather[0];
      weatherData = '城市：' + weatherData.currentCity + '\n' + 'PM2.5：' + weatherData.pm25 + '\n' + '日期：' + weatherData.date + '\n' + '温度：' + weatherData.temperature + '\n' + '天气：' + weatherData.weatherDesc + '\n' + '风力：' + weatherData.wind + '\n';
      that.setData({
        weatherData: weatherData
      });
    }
    // 发起weather请求 
    BMap.weather({
      fail: fail,
      success: success
    }); 
  },
  
  showSearchInfo: function (data, i) {
    var that = this;
    that.setData({
      placeData: {
        title: '名称：' + data[i].title + '\n',
        address: '地址：' + data[i].address + '\n',
        telephone: '电话：' + data[i].telephone
      }
    });
  },
  changeMarkerColor: function (data, i) {
    var that = this;
    var markers = [];
    consle.log("123")
    for (var j = 0; j < data.length; j++) {
      if (j == i) {
        // 此处需要在相应路径放置图片文件 
        data[j].iconPath = "../../photo/marker_yellow.png";
      } else {
        // 此处需要在相应路径放置图片文件 
        data[j].iconPath = "../../photo/marker_red.png";
      }
      markers[j](data[j]);
    }
    that.setData({
      markers: markers
    });
  },
  gogogo:function(){
    //wx.navigateTo({ url: "../intext/text" })
    var that = this
    var App=getApp()
    for(var i=0;i<5;i++){
      if ((that.data.latitud - that.data.markers[i].latitude < 0.005 && that.data.latitud - that.data.markers[i].latitude > -0.005) && (that.data.longitud - that.data.markers[i].longitude < 0.005 && that.data.longitud - that.data.markers[i].longitude > -0.005)){
        wx.showToast({
          title: that.data.markers[i].title,
          icon: 'success',
          duration: 2000
        })
        App.data.locatitle = that.data.markers[i].title
        console.log(App.data.locatitle)
        // that.data.markers[i].iconPath = "../../photo/marker_yellow.png";
        wx.navigateTo({ url: "../intext/text" })
        break;
    }

    }
    wx.showToast({
      title: '距离太远',
      icon: 'none',
      duration: 2000
    })
    
  }
  ,
  search:function(){
      var that=this;
    
    that.setData({
      si: that.data.essay
    });
    //var that = this;
    // 新建百度地图对象 
    var BMap = new bmap.BMapWX({
      ak: '0C0q7mvzf1ulOrpTQ1mXQqcOIemC8lYO'
    });
    var fail = function (data) {
      console.log(data)
    };
    var success = function (data) {
      wxMarkerData = data.wxMarkerData;
      that.setData({
        markers: wxMarkerData
      });
      that.setData({
        latitude: wxMarkerData[0].latitude
      });
      that.setData({
        longitude: wxMarkerData[0].longitude
      });
    }
    // 发起POI检索请求 
    BMap.search({
      "query": that.data.si,
      fail: fail,
      success: success,
      // 此处需要在相应路径放置图片文件 
      iconPath: '../../photo/marker_red.png',
      // 此处需要在相应路径放置图片文件 
      iconTapPath: '../../photo/marker_yellow.png'
    });
    var that = this;
    // 新建百度地图对象 
    var BMap = new bmap.BMapWX({
      ak: '0C0q7mvzf1ulOrpTQ1mXQqcOIemC8lYO'
    });
    var fail = function (data) {
      console.log(data)
    };
    var success = function (data) {
      var weatherData = data.currentWeather[0];
      weatherData = '城市：' + weatherData.currentCity + '\n' + 'PM2.5：' + weatherData.pm25 + '\n' + '日期：' + weatherData.date + '\n' + '温度：' + weatherData.temperature + '\n' + '天气：' + weatherData.weatherDesc + '\n' + '风力：' + weatherData.wind + '\n';
      that.setData({
        weatherData: weatherData
      });
    }
    // 发起weather请求 
    BMap.weather({
      fail: fail,
      success: success
    }); 
  },
  bindKeyInput: function (e) {
    console.log(e.detail.value)
    var that = this;
    that.setData({
      essay: "'" + e.detail.value+"'"
    })
  }
})