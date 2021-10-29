import viz
import vizshape


#Enable full screen anti-aliasing (FSAA) to smooth edges
viz.setMultiSample(4)

viz.go()

#Increase the Field of View
viz.MainWindow.fov(60)

piazza = viz.addChild('piazza.osgb')
"""
card = vizshape.addQuad(size=(1.0, 1.0), axis=-vizshape.AXIS_Z, cullFace = False, cornerRadius = 0.0)
card2 = vizshape.addQuad(size=(1.0, 1.0), axis=-vizshape.AXIS_Z, cullFace = False, cornerRadius = 0.0)
card3 = vizshape.addQuad(size=(1.0, 1.0), axis=-vizshape.AXIS_Z, cullFace = False, cornerRadius = 0.0)
card.setPosition([0, 0.2, 0])
card.setEuler([0, 90, 0])
card2.setPosition([1.1, 0.2, 0])
card2.setEuler([0, 90, 0])
card3.setPosition([0, 0.2, 1.1])
card3.setEuler([0, 90, 0])
"""

	#increment in lots of 1.1 on the x and z axis to get a 4x5 grid
	#20 cards total in the middle, then add the 3 in a pyramid shape on the outside of the grid. 

#Cards builder
crd = viz.addTexture('cardback.jpg')
cdx = -2.2
for i in range(5):
	cdy = -2.2
	card = vizshape.addQuad(size=(1.0, 1.0), axis=-vizshape.AXIS_Z, cullFace = False, cornerRadius = 0.0)
	card.setPosition([cdx, 0.2, 0])
	card.setEuler([0, 90, 0])
	card.texture(crd)
	for j in range(4):
		if cdy < 2.2:
				card = vizshape.addQuad(size=(1.0, 1.0), axis=-vizshape.AXIS_Z, cullFace = False, cornerRadius = 0.0)
				card.setPosition([cdx, 0.2, cdy])
				card.setEuler([0, 90, 0])
				card.texture(crd)
				cdy += 1.1
	cdx += 1.1
	

for i in range (2):
	cdy = 0
	for i in range(2):
		card = vizshape.addQuad(size=(1.0, 1.0), axis=-vizshape.AXIS_Z, cullFace = False, cornerRadius = 0.0)
		card.setPosition([cdx, 0.2, cdy])
		card.texture(crd)
		card.setEuler([0, 90, 0])
		cdy -= 1.1
	cdx = -cdx

cdx += 1.1
for i in range(2):
		card = vizshape.addQuad(size=(1.0, 1.0), axis=-vizshape.AXIS_Z, cullFace = False, cornerRadius = 0.0)
		card.setPosition([cdx, 0.2, -0.55])
		card.texture(crd)
		card.setEuler([0, 90, 0])
		cdx = -cdx

#need to do, see how easy it is to add flip effect to the card as a demonstration. 

viz.MainView.setPosition([0,7,-6])
viz.MainView.setEuler([0,50,0])
