import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ReceiptService} from "../services/receipt-service";
import {IReceiptDTO} from "../interfaces/IReceiptDTO";
import {AppConfig} from "../app-config";
import {IOrganizationDTO} from "../interfaces/IOrganizationDTO";

export var log = LogManager.getLogger('Receipt');

@autoinject
export class Receipt {

  private receiptDTO: IReceiptDTO;
  private organizations: IOrganizationDTO[];
  private selectedOrganization = null;
  
  constructor(
    private receiptService: ReceiptService,
    private appConfig: AppConfig,
    private router: Router
  ) {
    log.debug('constructor');
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
    if(this.appConfig.jwt == null) {
      this.router.navigateToRoute("identityLogin");
      return;
    }
    
    this.receiptService.fetch(params.id)
      .then(value => {
        this.receiptDTO = value;
        log.debug("receiptDTO object: ", this.receiptDTO)
      });

    this.receiptService.fetchOrganizations()
      .then(value => {
        this.organizations = value;
        log.debug("organizations: ", this.receiptDTO)
      });
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}