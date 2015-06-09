# Modo de desenvolvimento local:

* `npm install`
* `bower install`
* `npm start`

No modo de desenvolvimento local é colocado em execução um site em http://localhost:8080 com a aplicação cliente, e um site em http://localhost:8090 com o asset.js gerado pelo *webpack*.


# Modo de produção:

No modo de produção deve ser executado o comando:

* `npm run prod`

Este comando coloca na raíz deste projecto os ficheiros necessário à execução da aplicação cliente.

**Nota** É necessário garantir que todos os ficheiros desta pasta estão incluidos no projecto (.csproj). É necessário executar esta tarefa sempre que se adicionar uma dependência do tipo *bower*. 


