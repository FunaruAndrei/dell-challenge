import React, { Component } from "react";

class Delete extends Component {
 
  render() {
    return (
      <div>
        <h4>Deleted</h4>
        <hr></hr>
        <h3 className="text-success">The selected product was deleted!</h3>
        <a className="btn btn-light" href="/products">Go to products list</a>
      </div>
    );
  }
}

export default Delete;
