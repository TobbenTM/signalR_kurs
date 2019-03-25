const path = require('path');

module.exports = {
  devServer: {
    public: "https://localhost:44393/"
  },
  configureWebpack: {
    resolve: {
      alias: {
        "hubs": path.resolve(__dirname, '../Hubs/')
      }
    }
  }
};
