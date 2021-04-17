import java.util.HashMap; 

public class ControleMesa { 

    private HashMap<Integer, Mesa> Mesas = new HashMap<>();
    
    public void Adicionar(Mesa mesa) {
        Mesas.put(mesa.getNumero(), mesa);
    }
    
    public void Alterar(boolean status, int qtdCadeiras, Mesa mesa, Reserva reserva) {
       for (Mesa m : Mesas.values()) {
		if(m.getNumero() == mesa.getNumero()) {
			m.setDisponivel(status);
			m.setQtdCadeiras(qtdCadeiras);
			m.setReserva(reserva);
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
    
    public void Remover(Mesa mesa) {
        Mesas.remove(mesa.getNumero());
    }
}   