using UnityEngine;


public class movimientotopdown : MonoBehaviour
{
   [SerializeField] private float velocidadMovimiento;
   [SerializeField] private Vector2 direccion; 

   private Rigidbody2D rb2D;

   private float MovimientoX;
   private float MovimientoY;

   private Animator animator; 

   private void Start(){
      animator = GetComponent<Animator>();
    rb2D = GetComponent<Rigidbody2D>();
   }
   private void Update(){
      MovimientoX = Input.GetAxisRaw("Horizontal");
      MovimientoY = Input.GetAxisRaw("Vertical");
      animator.SetFloat("MovimientoX" ,MovimientoX);
      animator.SetFloat("MovimientoY" ,MovimientoY);

      if(MovimientoX != 0 || MovimientoY != 0){
         animator.SetFloat("UltimoX", MovimientoX);
         animator.SetFloat("UltimoY", MovimientoY);
      }
    direccion = new Vector2(MovimientoX, MovimientoY).normalized;
   }
  
   private void FixedUpdate()
   {
    rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
   }
}
