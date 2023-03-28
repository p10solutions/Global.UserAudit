# Global.UserAudit
É um microserviço que lida com o dominio de Auditoria dos Usuários, utilizando uma Web API .NET 6.
O microserviço <b>Global.UserAudit</b> se subscreve nas filas de inserção e alteração do microserviço <b>Global.UserManagement.Api</b> (https://github.com/p10solutions/Global.UserManagement) e registra todas as alterações que são realizadas nos registros 
deste microserviço para possibilitar um controle de auditoria e acesso ao histórico das mundaças.
Este microserviço utiliza o <b>RabbitMQ</b> para realizar a integração com o microserviço  <b>Global.UserManagement.Api</b>.

<b>Passo a Passo</b>

1. Execute o <b>docker-compose</b> na raiz deste repositório para que o banco <b>MongoDB</b> e o servidor <b>RabbitMQ</b> sejam criados

2. Execute o seguinte comando <b>dotnet Global.UserAudit.Worker.dll</b> para executar o Worker que contém os consumidores que fica na seguinte pasta:
<b>src\Global.UserAudit.Worker</b>

3. Execute o seguinte comando <b>dotnet Global.UserAudit.Api.dll</b> para executar a API que contém os endpoints de consulta dos registros da base de dados.
<b>src\Global.UserAudit.Api</b>

3. Acesse o endpoint da documentação da api em seu navegador https://localhost:7061/swagger/
