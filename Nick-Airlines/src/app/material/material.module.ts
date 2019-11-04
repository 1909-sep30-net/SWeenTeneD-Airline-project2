import { NgModule } from '@angular/core';
import {MatButtonModule, MatButtonToggleModule, MatIconModule, MatToolbarModule, MatSidenavModule} from '@angular/material';


const Material = [
  MatButtonModule,
  MatButtonToggleModule,
  MatIconModule,
  MatToolbarModule,
  MatSidenavModule
]

@NgModule({
  imports: [Material],
  exports: [Material]
})
export class MaterialModule { }
