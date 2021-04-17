import java.util.ArrayList;

public class ControleRestaurante {

	private ArrayList<Restaurante> restaurantes = new ArrayList<>();
	
	public void Adicionar(Restaurante restaurante) {
		restaurantes.add(restaurante);
	}
	
	public void Alterar(Restaurante res, String nome, String numeroTele) {
		for (Restaurante restaurante : restaurantes) {
			if(restaurante.getNome() == nome) {
				restaurante.setNome(nome);
				restaurante.setNumeroTelefone(numeroTele);
			}
		}
		
	}
	
	public String Listar(){
		String str = "";
		for (Restaurante restaurante : restaurantes) {
			str += restaurante.toString();
		}
		return str;
	}
	
	public void Remover(Restaurante restaurante) {
		restaurantes.remove(restaurante);
	}
	
	/*public static void main(String[] args) {
		// TODO Auto-generated method stub
			Mesa m = new Mesa(1, 2, true);
			Mesa m1 = new Mesa(2, 4, true);
			Mesa m2 = new Mesa(3, 3, false);
			Mesa m3 = new Mesa(4,4, false);
			Mesa m4 = new Mesa(5, 2, true);
			
			Restaurante restaurante = new Restaurante("Restaurante 1", "12345678");
			Restaurante restaurante1 = new Restaurante("Restaurante 2", "12345679");
			
			restaurante.addMesa(m);
			restaurante.addMesa(m1);
			restaurante.addMesa(m2);
			restaurante.addMesa(m3);
			restaurante.addMesa(m4);
			
			restaurante1.addMesa(m4);
			restaurante1.addMesa(m1);
			
			ControleRestaurante control = new ControleRestaurante();
			control.Adicionar(restaurante);
			control.Adicionar(restaurante1);
			
			System.out.println(control.Listar());
			control.Alterar(restaurante, "Alterado 1", null);
			System.out.println("-------------------------");
			System.out.println(control.Listar());
			System.out.println("-------------------------");
			control.Remover(restaurante1);
			System.out.println(control.Listar());
	}*/

}
