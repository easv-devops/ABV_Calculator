import { Selector } from 'testcafe';

fixture('ABV Calculation').page('https://localhost:8081/AbvCalculatorModel');

test('Valid input', async t => {
    // Define selectors with visibility check and timeout
    const originalGravityInput = Selector('#originalGravity').with({ visibilityCheck: true, timeout: 10000 });
    const finalGravityInput = Selector('#finalGravity').with({ visibilityCheck: true, timeout: 10000 });
    const calculateButton = Selector('.btn.btn-primary').with({ visibilityCheck: true, timeout: 10000 });
    const resultLabel = Selector('strong').withText('ABV:'); // More specific selector for the label

    await t
        // Wait for the elements to exist and be visible
        .expect(originalGravityInput.exists).ok({ timeout: 10000 })
        .expect(finalGravityInput.exists).ok({ timeout: 10000 })
        .expect(calculateButton.exists).ok({ timeout: 10000 })
        .expect(originalGravityInput.visible).ok({ timeout: 10000 })
        .expect(finalGravityInput.visible).ok({ timeout: 10000 })
        .expect(calculateButton.visible).ok({ timeout: 10000 })

        // Arrange
        .typeText(originalGravityInput, '1.9')
        .typeText(finalGravityInput, '1.8')

        // Act
        .click(calculateButton)

        // Assert
        .expect(resultLabel.innerText).contains("13.13");
});