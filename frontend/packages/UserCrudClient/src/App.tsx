import React from "react";
import ReactDOM from "react-dom";

import { UserIndex } from "./components/UserIndex";

import "./index.css";

const App = () => (
  <div className="container">
    <UserIndex />
  </div>
);
ReactDOM.render(<App />, document.getElementById("app"));
