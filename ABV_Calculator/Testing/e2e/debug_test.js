import { Selector } from 'testcafe';

fixture('ABV Calculation').page('https://localhost:8081/AbvCalculatorModel');

test('Debugging Test', async t => {
    await t
        .wait(60000)
        // Arrange
        .typeText(Selector('[name="OriginalGravity"]'), '1.9')
        .typeText('#finalGravity', '1.8')
        
        // Act
        .click('.btn.btn-primary')
        
        // Assert
      //  .expect('strong').withText('ABV:').innerText.contains("13.13");
        .expect(Selector('.form-control').innerText).eql('13.13');
});
