package Server;
import javax.xml.ws.Endpoint;


public class RestauranteServerPublisher {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Endpoint.publish("http://localhost:9876/restauranteControle", new ControleRestaurante());
		Endpoint.publish("http://localhost:9876/mesa", new ControleMesa());
	}

}
