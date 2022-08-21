# donet-metrics-influxdb-grafana
Demonstração de como podemos gravar as métricas da aplicação no InfluxDB para posterior exibição no Grafana. 	  

# Como executar:
- Clonar / baixar o repositório em seu workplace.
- Baixar o .Net Core SDK e o Visual Studio / Code mais recentes.
- A infraestrutura da aplicação será criada através do docker compose /docker/docker_infrastructure.yml.
- Conectar no InfluxDB (http://localhost:8086/) onde deverá ser criado uma organizalçao, bucket e API Token.
- Atualize o projeto com essas informações.
- Conecte o Grafana (http://localhost:3000/) no InfluxDB.

# Sobre
Este projeto foi desenvolvido por Anderson Hansen sob [MIT license](LICENSE).
