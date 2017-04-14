var Path = require("path");
var Webpack = require("webpack");
var Chalk = require("chalk");
var AssetsPlugin = require("assets-webpack-plugin");
//var ExtractTextPlugin = require("extract-text-webpack-plugin");

var BuildMode = {
    Production: "production",
    Development: "development",
    DevelopmentWithoutDevtool: "developmentWithoutDevtool",
    DevelopmentRebuildFast: "developmentRebuildFast"
}

var NodeEnv = process.env.NODE_ENV || BuildMode.Development;
console.log(Chalk.magenta(`Execute mode: ${NodeEnv}`));

module.exports = {
    context: Path.join(__dirname, "app"),
    entry: {
        sharedLayout: [ "bootstrap-loader/lib/bootstrap.loader" + 
            "?" + /*"extractStyles"*/  `&configFilePath=${__dirname}/.bootstraprc.json!bootstrap-loader/no-op.js`, "./layout/layout/layout.js" ],
        homeIndex: "./layout/index/index.js"
    },
    output: {
        path: Path.join(__dirname, "bundles"),
        filename: "[name].js",
        publicPath: "/bundles/",
        chunkFilename: "[id].js"
    },
    resolve: {
        modules: [ Path.join(__dirname, "app", "lib"), "node_modules" ],
        extensions: [ ".js", ".css" ]
    },
    resolveLoader: {
        modules: [ "node_modules" ],
        extensions: [ ".js", ".loader.js" ]
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: "babel-loader",
                        options: {
                            plugins: "transform-runtime",
                            presets: [ "es2015" ]
                        }
                    }
                ]
            },
            {
                test: /\.jsx$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: "babel-loader",
                        options: {
                            plugins: [ "transform-runtime", "syntax-jsx" ],
                            presets: [ "es2015", "react" ]
                        }
                    }]
            },
            //{
            //    test: /\.css$/,
            //    use: ExtractTextPlugin.extract({
            //        fallback: "style-loader",
            //        use: [ "css-loader", "autoprefixer-loader?browsers=last 2 version" ]
            //    })
            //},
            //{
            //    test: /\.sass$/,
            //    use: ExtractTextPlugin.extract({
            //        fallback: "style-loader",
            //        use: [ "css-loader", "autoprefixer-loader?browsers=last 2 version", "sass-loader" ]
            //    })
            //},
            //{
            //    test: /\.less$/,
            //    use: ExtractTextPlugin.extract({
            //        fallback: "style-loader",
            //        use: [ "css-loader", "autoprefixer-loader?browsers=last 2 version", "less-loader" ]
            //    })
            //},
            {
                test: /\.css$/,
                use: [ "style-loader", "css-loader", "autoprefixer-loader?browsers=last 2 version"]
            },
            {
                test: /\.scss$/,
                use: [ "style-loader", "css-loader", "autoprefixer-loader?browsers=last 2 version", "sass-loader" ]
            },
            {
                test: /\.less$/,
                use: [ "style-loader", "css-loader", "autoprefixer-loader?browsers=last 2 version", "less-loader" ]
            },
            {
                test: /\.(png|jpg)$/,
                use: [
                    {
                        loader: "file-loader",
                        options: {
                            name: "[name].[ext]"
                        }
                    }
                ]
            },
            {
                test: /\.eot(\?v=\d+\.\d+\.\d+)?$/,
                use: [
                    {
                        loader: "file-loader",
                        options: {
                            name: "[name].[ext]"
                        }
                    }
                ]
            },
            {
                test: /\.woff(2)?(\?v=\d+\.\d+\.\d+)?$/,
                use: [
                    {
                        loader: "file-loader",
                        options: {
                            name: "[name].[ext]",
                            limit: 10000,
                            minetype: "application/font-woff"
                        }
                    }
                ]
            },
            {
                test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/,
                use: [
                    {
                        loader: "file-loader",
                        options: {
                            name: "[name].[ext]",
                            limit: 10000,
                            minetype: "application/octet-stream"
                        }
                    }
                ]
            },
            {
                test: /\.svg(\?v=\d+\.\d+\.\d+)?$/,
                use: [
                    {
                        loader: "file-loader",
                        options: {
                            name: "[name].[ext]",
                            limit: 10000,
                            minetype: "image/svg+xml"
                        }
                    }
                ]
            }
        ]
    },
    plugins: [
        //new ExtractTextPlugin({filename: "stylesheets/[name].css"}),
        //new ExtractTextPlugin({filename: "stylesheets/[name].sass"}),
        //new ExtractTextPlugin({filename: "stylesheets/[name].less"}),
        new Webpack.NoEmitOnErrorsPlugin(),
        new Webpack.DefinePlugin({
            NODE_ENV: JSON.stringify(NodeEnv)
        }),
        new Webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            "window.jQuery": "jquery"
        }),
        new Webpack.optimize.CommonsChunkPlugin({ name: "common" }),
        new AssetsPlugin({ path: Path.join(__dirname) })
    ]
};

if (NodeEnv === BuildMode.Production) {
    console.log(Chalk.bgYellow("Using plugins: UglifyJsPlugin"));
    module.exports.plugins.push(new Webpack.optimize.UglifyJsPlugin({
        compress: {
            drop_console: true,
            unsafe: true
        }
    }));
}

if (NodeEnv === BuildMode.Development || NodeEnv === BuildMode.Production) {
    console.log(Chalk.bgYellow("Using devtool: source-map"));
    module.exports.devtool = "source-map";
}

if (NodeEnv === BuildMode.DevelopmentRebuildFast) {
    console.log(Chalk.bgYellow("Using devtool: eval"));
    module.exports.devtool = "eval";
}