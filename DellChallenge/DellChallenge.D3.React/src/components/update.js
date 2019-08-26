import React, { Component } from "react";
import Validation from "../validation";
import $ from "jquery";

class Update extends Component {
  constructor() {
    super();
    this.state = {
      error: null,
      isLoaded: false,
      Name: "",
      Category: "",
      Id: "",
      Success: false
    };

    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleSubmit = event => {
    

    if($("#updateProductForm").valid()){

        event.preventDefault();

    let putData = {
        Id: this.state.Id,
        Name: this.state.Name,
        Category: this.state.Category
      };
  
      fetch("http://localhost:5000/api/products/" + this.state.Id, {
        method: "PUT",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        mode: "cors",
        body: JSON.stringify(putData)
      })
      .then(res => res.json())
      .then(this.props.history.push('/products'))
      .catch(err => console.log(err));

    }
  };

  handleInputChange = event => {
    const target = event.target;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  };

  componentDidMount() {


   

    fetch("http://localhost:5000/api/products/" + this.props.match.params.id)
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            Name: result.name,
            Category: result.category,
            Id: result.id
          });

          $("#updateProductForm").validate({
            rules: {
              Name: "required"
            },
            messages: {
              Name: "Please enter a name!"
            }
          });
          
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      );
  }

  render() {
    const { error, isLoaded } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
        <form id="updateProductForm" onSubmit={this.handleSubmit}>
          <h4>Update Product</h4>
          <div className="form-group">
            <label className="control-label" htmlFor="Id">
              Id
            </label>
            <input
              className="form-control"
              type="text"
              id="Id"
              name="Id"
              disabled
              value={this.state.Id}
            />
          </div>
          <div className="form-group">
            <label className="control-label" htmlFor="Name">
              Name
            </label>
            <input
              className="form-control"
              type="text"
              id="Name"
              name="Name"
              onChange={this.handleInputChange}
              value={this.state.Name}
            />
            <span
              className="text-danger field-validation-valid"
              data-valmsg-for="Name"
              data-valmsg-replace="true"
            />
          </div>
          <div className="form-group">
            <label className="control-label" htmlFor="Category">
              Category
            </label>
            <input
              className="form-control"
              type="text"
              id="Category"
              name="Category"
              onChange={this.handleInputChange}
              value={this.state.Category}
            />
            <span
              className="text-danger field-validation-valid"
              data-valmsg-for="Category"
              data-valmsg-replace="true"
            />
          </div>
          <div className="form-group">
            <button className="btn btn-primary">Submit</button>
          </div>
          <Validation />
        </form>
      );
    }
  }
}

export default Update;
