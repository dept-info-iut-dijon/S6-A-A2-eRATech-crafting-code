package tax.simulator.api;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import tax.simulator.Simulateur;

@RestController
@RequestMapping("/api/tax")
public class TaxController {
    private final Simulateur simulateur;

    public TaxController(Simulateur simulateur) {
        this.simulateur = simulateur;
    }

    @GetMapping("/calculate")
    public ResponseEntity<?> calculateTax(
            @RequestParam String situationFamiliale,
            @RequestParam double salaireMensuel,
            @RequestParam double salaireMensuelConjoint,
            @RequestParam int nombreEnfants) {
        try {
            return ResponseEntity.ok(
                    simulateur.calculerImpotsAnnuel(
                            situationFamiliale,
                            salaireMensuel,
                            salaireMensuelConjoint,
                            nombreEnfants
                    )
            );
        } catch (IllegalArgumentException ex) {
            return ResponseEntity.badRequest().body(ex.getMessage());
        }
    }
}
