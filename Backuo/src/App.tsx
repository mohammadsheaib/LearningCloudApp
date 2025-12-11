import React from "react";
import ProductList from "./components/ProductList";
import OrderForm from "./components/OrderForm";

function App() {
  return (
    <div style={{ padding: "20px" }}>
      <h1>Mini Shop</h1>

      <ProductList />
      <hr />
      <OrderForm />
    </div>
  );
}

export default App;
