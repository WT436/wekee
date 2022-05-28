import * as React from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';
import { Col, Row, Tooltip } from 'antd';

import Footer from '../Footer';
import { userRouters } from '../Router/router.config';
import Header from '../Header';
import { BellOutlined, ClockCircleOutlined, CommentOutlined, CreditCardOutlined, CrownOutlined, EyeOutlined, HistoryOutlined, HomeOutlined, QuestionCircleOutlined, ShoppingCartOutlined, SkinOutlined, SnippetsOutlined } from '@ant-design/icons';
import { Helmet } from 'react-helmet';
declare var abp: any;

interface MyState {
  AvatarAccount: string
}

class UserLayout extends React.Component<any, MyState> {
  constructor(props: any) {
    super(props);
    this.state = { AvatarAccount: this.processAccount() };
  }

  processAccount = () => {
    var data = abp.utils.getCookieValue('_pus');
    var isToken = data === null || data === undefined || data === "";
    if (!isToken) {
      let result = data.split(/[|]/i);
      if (result.toString().toUpperCase().indexOf("https".toUpperCase) != -1) {
       // this.setState({ AvatarAccount: result[1].trim() });
        return result[1].trim();
      }
      else {
        //this.setState({ AvatarAccount: abp.serviceAlbumImage + result[1].trim() });
        return abp.serviceAlbumImage + result[1].trim();
      }
    }
    else {
      //this.setState({ AvatarAccount: abp.serviceAlbumImage + "/album/imageSystem/facebook.png" });
      return abp.serviceAlbumImage + "/album/imageSystem/facebook.png";
    }
  }

  render() {
    return (
      <Col className="container">
        <Helmet>
          <link rel="stylesheet" href={abp.serviceAlbumCss + "/lohkKcjUzB.css"} />
        </Helmet>
        <Header />
        <ul className='GjLseculzy'>
          <li><a href="/"><HomeOutlined /></a></li>
          <li><a className="GjLseculzyac">Tài khoản</a></li>
          <li><a className="GjLseculzyac">Thay đổi mật khẩu</a></li>
        </ul>
        <div className="uPWuUYCLKg">
          <div className="ketltnDWvz">
            <Tooltip placement="right" title="Tài khoản">
              <img src={this.state.AvatarAccount} alt="" onClick={() => window.location.href = "/user"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("hainam") !== -1 ? "bKKOQwNcRv" : ""} title="Thông báo">
              <BellOutlined onClick={() => window.location.href = "/user"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("/user/order") !== -1 ? "bKKOQwNcRv" : ""} title="Đơn hàng">
              <SnippetsOutlined onClick={() => window.location.href = "/user/order"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("hainam") !== -1 ? "bKKOQwNcRv" : ""} title="Thanh toán">
              <CreditCardOutlined onClick={() => window.location.href = "/user"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("hainam") !== -1 ? "bKKOQwNcRv" : ""} title="Nhận xét">
              <CommentOutlined onClick={() => window.location.href = "/user"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("hainam") !== -1 ? "bKKOQwNcRv" : ""} title="Sản phẩm">
              <SkinOutlined onClick={() => window.location.href = "/user"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("/user/viewed") !== -1 ? "bKKOQwNcRv" : ""} title="Sản phẩm">
              <EyeOutlined onClick={() => window.location.href = "/user/viewed"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("hainam") !== -1 ? "bKKOQwNcRv" : ""} title="Mua sau">
              <ShoppingCartOutlined onClick={() => window.location.href = "/user"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("hainam") !== -1 ? "bKKOQwNcRv" : ""} title="Hỏi đáp">
              <QuestionCircleOutlined onClick={() => window.location.href = "/user"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("hainam") !== -1 ? "bKKOQwNcRv" : ""} title="Mã giảm giá">
              <CrownOutlined onClick={() => window.location.href = "/user"} />
            </Tooltip>
            <Tooltip placement="right" className={window.location.href.indexOf("hainam") !== -1 ? "bKKOQwNcRv" : ""} title="Lịch sử">
              <HistoryOutlined onClick={() => window.location.href = "/user"} />
            </Tooltip>
          </div>
          <div className="rMKPiDIrMS">
            <Switch>
              {userRouters
                .filter((item: any) => !item.isLayout)
                .map((item: any, index: number) => (
                  <Route key={index} path={item.path} component={item.component} exact={item.exact} />
                ))}
              <Redirect from="/user" to="/user" />
            </Switch>
          </div>
        </div>
        <Footer />
      </Col>
    );
  }
}

export default UserLayout;
