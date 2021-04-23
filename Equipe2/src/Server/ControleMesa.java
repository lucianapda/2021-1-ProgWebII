package Server;
import java.util.HashMap; 
import java.util.Date;
import javax.jws.WebService;

@WebService(endpointInterface = "Server.ControleMesaServer")
public class ControleMesa implements ControleMesaServer{ 

    public HashMap<Integer, Mesa> Mesas = new HashMap<>();
    
    public void Adicionar(Mesa mesa) {
        Mesas.put(mesa.getNumero(), mesa);
    }
    
    public void Alterar(boolean status, int qtdCadeiras, Mesa mesa) {
       for (Mesa m : Mesas.values()) {
		if(m.getNumero() == mesa.getNumero()) {
			m.setDisponivel(status);
			m.setQtdCadeiras(qtdCadeiras);
		}
      }          
    }
    
    public String Listar(){
        String str = "";
        for (Mesa mesa : Mesas.values()) {
            str += mesa.toString();
        }
        return str;
    }

}   