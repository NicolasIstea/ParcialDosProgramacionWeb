import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Usuario } from '../modelos/usuario';
import { UsuarioService } from '../servicios/usuario.service';

@Component({
  selector: 'app-registracion',
  templateUrl: './registracion.component.html',
  styleUrls: ['./registracion.component.css']
})
export class RegistracionComponent implements OnInit {

  hide = true;
  public pagoFormulario: FormGroup = new FormGroup({ });
  public titulo = "Registracion de Usuario"

  constructor(public fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private _usuarioServicio: UsuarioService) { }


  ngOnInit(): void {
    this.formularioReactivo();
  }

  formularioReactivo() {

    this.pagoFormulario = this.fb.group({
      nombre: [null, { validators: [ Validators.required, Validators.pattern('[a-zA-Z]*'), Validators.maxLength(20) ]}],
      apellido: [null, { validators: [ Validators.required, Validators.pattern('[a-zA-Z]*'), Validators.maxLength(20) ]}],
      dni: [null, { validators: [ Validators.required, Validators.pattern('[0-9]+(\.[0-9]{2}?)?'), Validators.maxLength(9), Validators.minLength(7) ]}],
      usuarioNombre: [null, { validators: [ Validators.required, Validators.pattern('[a-zA-Z]*'), Validators.maxLength(20) ]}],
      contraseña: [null, { validators: [ Validators.required ] }],    
    })
  }

  submitFormulario() {

    if(this.pagoFormulario.valid) {

      
      let usuario:Usuario = this.pagoFormulario.value as Usuario;
      usuario.contraseña = btoa(usuario.contraseña);

        this._usuarioServicio.crearUsuario(usuario)
        .subscribe(
          (data) => { 
            this.openSnackBar(`Usuario ${data.nombre} ${data.apellido} creado correctamente`, "Ok"); 
          },
          error => {
            if(error.status == 500) {
              this.openSnackBar("No se puede realizar esta accion en este momento, por favor espere unos momentos y vuelva a realizarlo", "Ok");
              return;
            }

            if(error.status == 400 && error.error == "2601"){
              this.openSnackBar("Usuario ya existe, elija otro", "Ok");
              return;
            }

            this.openSnackBar(error.error, "Ok");
          });
    }
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action);
  }

}
