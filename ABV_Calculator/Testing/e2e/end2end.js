import { Selector } from 'testcafe';

//fixture('ABV Calculation').page('http://localhost:8081/ABVCalculator');
//fixture('ABV Calculation').page('http://5.189.148.90:8081/AbvCalculatorModel');
fixture('ABV Calculation').page('http://5.189.134.176:8082/AbvCalculatorModel');



test('Valid input', async t => {

    await t
        .wait(5000)
      //  .expect(Selector('#originalGravity').exists).ok({ timeout: 10000 })
      
       // Arrange
        .typeText('#originalGravity', '1.9')
        .typeText('#finalGravity', '1.8')
        .wait(2000)
        // Act
        .click('.btn.btn-primary')
        .wait(2000)
        // Assert
        .expect(Selector('#resultsSection').innerText).contains("13.13%");
});
