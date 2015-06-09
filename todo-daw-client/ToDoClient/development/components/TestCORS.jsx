import React from "react";
import { Alert } from "react-bootstrap"
import { Link } from "react-router";

// TestCORS
export default React.createClass(
{
  getInitialState()
  {
    return {
        api: "http://local.todo-daw-api.apphb.com/api/info/db",
        loadingResponse: false,
        response: {}
    }; 
  },

  componentDidMount()
  {
    this.makeAjaxRequest();
  },

  makeAjaxRequest()
  {
    this.setState({loadingResponse: true})
    fetch(this.state.api)
        .then(res => res.json())
        .then(data => this.setState({ response: data, loadingResponse: false}))
        .catch(err => this.setState({ response: err.toString(), loadingResponse: false }))
  },

  handleAPIChange(evt)
  {
    this.setState({ api: evt.target.value });
  },

  render()
  {
    return (
      <div>
        <div className="row">
          <Alert>
            <strong>CORS</strong> Esta página mostra o resultado da chamada à API.
          </Alert>
        </div>
        <div className="row">

          <div className="input-group">
            <input type="text" className="form-control" value={this.state.api} onChange={this.handleAPIChange} />
            <span className="input-group-btn">
              <button className="btn btn-default" type="button" onClick={this.makeAjaxRequest}>Go!</button>
            </span>
          </div>

        </div>
        
        <hr/>
        <div className="row">
            <pre>
              {this.state.loadingResponse ? 
                  "Loading..." : 
                  JSON.stringify(this.state.response, null, 2)
              }
            </pre>
        </div>
      </div>
    );
  },


});
