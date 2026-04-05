# Desafio Técnico Inoa

## Sobre o Projeto
Esta é uma aplicação de console desenvolvida em C# que monitora continuamente a cotação de um ativo. O sistema avisa via e-mail caso a cotação do ativo caia abaixo de um nível de compra estipulado ou suba acima de um nível de venda de referência.

## Tecnologias Utilizadas
* Linguagem: C# (.NET 10.0).
* API de Cotação: Brapi.

## Decisões de Arquitetura
* Padrão de Projeto: O sistema foi desenhado utilizando uma máquina de estados. Isto impede o envio excessivo de e-mails em formato de "spam" enquanto o preço se mantiver acima ou abaixo do limiar, garantindo que o alerta seja disparado apenas nas transições de mercado.
* Fail-fast e Validações: Antes de começar a monitorização, a aplicação valida se o preço de venda é coerente, garante o formato correto do e-mail do investidor e realiza um pré-teste na API para confirmar que o ativo é válido.
* Resiliência: O loop principal possui tratamento de exceções para suportar falhas intermitentes de internet ou indisponibilidade temporária da API, permitindo que a aplicação aguarde o próximo ciclo.

## Como Configurar
* Clone o repositório para o seu ambiente local.
* Na pasta raiz, localize o ficheiro de exemplo e crie o seu arquivo de configuração `.config.json`.
* Edite o ficheiro informando o e-mail de destino dos alertas e as configurações de acesso ao servidor SMTP que irá realizar os envios. 

Exemplo de formato para o .config.json:
```json
{
  "Servidor": "smtp.gmail.com",
  "Porta": 587,
  "Usuario": "seu_email@gmail.com",
  "Senha": "sua_senha_ou_app_password",
  "EmailDestino": "investidor_destino@gmail.com"
}
```

## Como Executar
* O programa é uma aplicação de console sem interface gráfica e deve ser chamado via linha de comando.
* Ele requer exatamente 3 parâmetros na seguinte ordem: o ativo a ser monitorado, o preço de referência para venda e o preço de referência para compra.
* Exemplo de uso: `dotnet run PETR4 48,16 48,14`.

## Autor
* Luís Rafael Sena.

## Observação
* Esse projeto foi escrito com auxílio do Gemini, os trechos de maior participação do modelo se encontram na integração da API e do SMTP