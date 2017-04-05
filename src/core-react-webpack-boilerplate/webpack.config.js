var path = require('path');
var webpack = require('webpack');
var CleanWebpackPlugin = require('clean-webpack-plugin');

module.exports = {
  context: __dirname,
  entry: { main: ['./content/js/index.tsx'] },
  output: {
    path: path.resolve('wwwroot/bundles'),
    publicPath: 'wwwroot/bundles/',
    filename: '[name].js'
  },
  devtool: 'source-map',

  module: {
    loaders: [
      { test: /\.tsx?$/, loader: 'ts-loader' }
    ]
  },

  plugins: [
    new CleanWebpackPlugin(
      [
        'wwwroot/bundles',
      ]
    ),
  ],

  resolve: {
    extensions: ['.js', '.ts', '.tsx', '.html']
  }
}