/*
 * Autroes: Eduarda Engels, Giancarlo Cavalli, Gustavo Felipe Soares e Jardel Pereira Zermiani
 */

package controller;

import javax.xml.ws.Endpoint;

public class PedidoServerPublisher {

	public static void main(String[] args) {
		Endpoint.publish("http://127.0.0.1:9876/controller", new PedidoController());
	}

}
