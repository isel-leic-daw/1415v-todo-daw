import React from "react";
import { Alert } from "react-bootstrap"
import { Link } from "react-router";

// Welcome
export default React.createClass(
{
  render: function() {

    fetch("http://local.todo-daw-api.apphb.com/api/info/db")
        .then(res => res.json())
        .then(data => console.log("data", data));

    return (
      <Alert>
        <strong>Bem-vindo</strong> à aplicação de Listas de Todos.
        Começe <Link to="todos">aqui</Link>.
      </Alert>
    );
  },


});
