import React, { Component } from "react";
import Validation from "../validation";

class ProductList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };

    this.handleDelete = this.handleDelete.bind(this);
    this.handleEdit = this.handleEdit.bind(this);

  }

  handleEdit(item){

    this.props.history.push('/update/' + item.id);

  }

  handleDelete(item){

    fetch("http://localhost:5000/api/products/" + item.id, {
      method: "DELETE",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      mode: "cors"
    })
    .then(()=>this.props.history.push('/delete'))
    .catch(err => console.log(err));

  }

  componentDidMount() {
    fetch("http://localhost:5000/api/products")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result
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
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
          <div className="container-fluid">
            {items.map(item => (
              <div className="row-fluid mb-2" key={item.id}>
                {item.name} - {item.category}
                <div className="float-right">
                  <button className="btn btn-sm btn-danger mr-1"
                  onClick={this.handleDelete.bind(this, item)}>
                    Sterge
                  </button>
                  <button className="btn btn-sm btn-primary"
                  onClick={this.handleEdit.bind(this, item)}>
                    Editeaza
                  </button>
                </div>
                <hr />
              </div>
            ))}
          </div>
      );
    }
  }
}

class Products extends Component {
  render() {
    return (
      <React.Fragment>
        <h1 className="display-4">Products</h1>
        <ProductList history={this.props.history} />
        <Validation />
      </React.Fragment>
    );
  }
}
export default Products;
