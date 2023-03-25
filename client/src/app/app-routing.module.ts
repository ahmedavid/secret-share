import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { SecretCreateComponent } from './secret/secret-create/secret-create.component';
import { SecretCreatedComponent } from './secret/secret-created/secret-created.component';
import { SecretViewComponent } from './secret/secret-view/secret-view.component';

const routes: Routes = [
  { path: '', redirectTo: 'secret', pathMatch: 'full' },
  { path: 'not-found', component: NotFoundComponent },
  {
    path: 'secret',
    children: [
      { path: '', component: SecretCreateComponent },
      { path: 'created/:id', component: SecretCreatedComponent },
      { path: 'view/:id', component: SecretViewComponent },
    ],
  },
  { path: '**', redirectTo: 'secret', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
